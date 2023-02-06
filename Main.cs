using FontAwesome.Sharp;
using MySql.Data.MySqlClient;
using System.Data;
using System.Runtime.InteropServices;

namespace enciclopediaMejorada
{
    public partial class Main : Form
    {
        static bool isClickedArts = false;
        static bool isClickedPolitics = false;
        static bool isClickedScience = false;
        static bool isClickedReligion = false;
        static bool isClickedHistory = false;
        static bool isClickedGeography = false;
        static bool isClickedSociety = false;
        static bool isClickedTech = false;
        // Database connection
        MySqlConnection connection = new MySqlConnection("datasource=localhost; port=3307; username=root; password=admin; database=enciclopedia");
        // Fields
        private IconButton currentBtn;
        private Panel leftBorderBtn;

        // Constructor
        public Main()
        {
            try
            {
                connection.Open();
                connection.Close();
            }
            catch (MySqlException ex)
            {
                throw new InvalidOperationException("Error al conectar con el servidor", ex);
            }
            InitializeComponent();
            this.CenterToScreen();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            this.Text = String.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        // Structs
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
            public static Color color7 = Color.FromArgb(0, 203, 0);
            public static Color color8 = Color.FromArgb(255, 255, 0);
        }

        // Methods
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                // Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                // Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                // Icon Current Child Form
                iconCurrentChidForm.IconChar = currentBtn.IconChar;
                iconCurrentChidForm.IconColor = color;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.White;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void dataGridViewInfo_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
            dataGridViewCellStyle.ForeColor = Color.White;
            dataGridViewCellStyle.BackColor = Color.FromArgb(37, 36, 81);
            
            if (e.RowIndex > -1)
            {
                dataGridViewInfo.Rows[e.RowIndex].DefaultCellStyle = dataGridViewCellStyle;
            }
        }

        private void dataGridViewInfo_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
            dataGridViewCellStyle.ForeColor = Color.White;
            dataGridViewCellStyle.BackColor = Color.FromArgb(26, 25, 62);

            if (e.RowIndex > -1)
            {
                dataGridViewInfo.Rows[e.RowIndex].DefaultCellStyle = dataGridViewCellStyle;
            }
        }

        private void buttonHistory_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            lblTitleChildForm.Text = "Historia";
            isClickedHistory = true;
            this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            MySqlCommand mySqlCommand = new MySqlCommand("SELECT Historia FROM categorias", connection);
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);
            dataGridViewInfo.DataSource = dataTable;
            dataGridViewInfo.CurrentRow.Selected = false;
        }

        private void buttonGeography_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            lblTitleChildForm.Text = "Geografia";
            isClickedGeography = true;
            this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            MySqlCommand mySqlCommand = new MySqlCommand("SELECT Geografia FROM categorias", connection);
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);
            dataGridViewInfo.DataSource = dataTable;
            dataGridViewInfo.CurrentRow.Selected = false;
        }

        private void buttonSociety_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            lblTitleChildForm.Text = "Sociedad";
            isClickedSociety = true;
            this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            MySqlCommand mySqlCommand = new MySqlCommand("SELECT Sociales FROM categorias", connection);
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);
            dataGridViewInfo.DataSource = dataTable;
            dataGridViewInfo.CurrentRow.Selected = false;
        }

        private void buttonTech_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            lblTitleChildForm.Text = "Tecnologia";
            isClickedTech = true;
            this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            MySqlCommand mySqlCommand = new MySqlCommand("SELECT Tecnologias FROM categorias", connection);
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);
            dataGridViewInfo.DataSource = dataTable;
            dataGridViewInfo.CurrentRow.Selected = false;
        }

        private void buttonArts_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            lblTitleChildForm.Text = "Arte";
            isClickedArts = true;
            this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            MySqlCommand mySqlCommand = new MySqlCommand("SELECT Artes FROM categorias", connection);
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);
            dataGridViewInfo.DataSource = dataTable;
            dataGridViewInfo.CurrentRow.Selected = false;
        }

        private void buttonPolitics_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            lblTitleChildForm.Text = "Politica";
            isClickedPolitics = true;
            this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            MySqlCommand mySqlCommand = new MySqlCommand("SELECT Politica FROM categorias", connection);
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);
            dataGridViewInfo.DataSource = dataTable;
            dataGridViewInfo.CurrentRow.Selected = false;
        }

        private void buttonReligion_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color7);
            lblTitleChildForm.Text = "Religion";
            isClickedReligion = true;
            this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            MySqlCommand mySqlCommand = new MySqlCommand("SELECT Religion FROM categorias", connection);
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);
            dataGridViewInfo.DataSource = dataTable;
            dataGridViewInfo.CurrentRow.Selected = false;
        }

        private void buttonScience_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color8);
            lblTitleChildForm.Text = "Ciencia";
            isClickedScience = true;
            this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            MySqlCommand mySqlCommand = new MySqlCommand("SELECT Ciencias FROM categorias", connection);
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);
            dataGridViewInfo.DataSource = dataTable;
            dataGridViewInfo.CurrentRow.Selected = false;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChidForm.IconChar = IconChar.Home;
            iconCurrentChidForm.IconColor = Color.White;
            lblTitleChildForm.Text = "Inicio";
            dataGridViewInfo.DataSource = "";
        }

        // Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void dataGridViewInfo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == 0)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Procariontes FROM botanica", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridViewInfo.DataSource = dataTable;
                this.dataGridViewInfo.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
                dataGridViewInfo.CurrentRow.Selected = false;
            }

            if (e.RowIndex == 1)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Eucariontes FROM botanica", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridViewInfo.DataSource = dataTable;
                this.dataGridViewInfo.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
                dataGridViewInfo.CurrentRow.Selected = false;
            }

            if (e.RowIndex == 2)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Schizophyta FROM botanica", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridViewInfo.DataSource = dataTable;
                this.dataGridViewInfo.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
                dataGridViewInfo.CurrentRow.Selected = false;
            }

            if (e.RowIndex == 3)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Cyanobacteria FROM botanica", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridViewInfo.DataSource = dataTable;
                this.dataGridViewInfo.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
                dataGridViewInfo.CurrentRow.Selected = false;
            }

            if (e.RowIndex == 4)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Chlorophyta FROM botanica", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridViewInfo.DataSource = dataTable;
                this.dataGridViewInfo.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
                dataGridViewInfo.CurrentRow.Selected = false;
            }

            if (e.RowIndex == 5)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Dinoflagellata FROM botanica", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridViewInfo.DataSource = dataTable;
                this.dataGridViewInfo.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
                dataGridViewInfo.CurrentRow.Selected = false;
            }

            if (e.RowIndex == 6)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Rhodophyta FROM botanica", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridViewInfo.DataSource = dataTable;
                this.dataGridViewInfo.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
                dataGridViewInfo.CurrentRow.Selected = false;
            }

            if (e.RowIndex == 7)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Mycetozoa FROM botanica", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridViewInfo.DataSource = dataTable;
                this.dataGridViewInfo.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
                dataGridViewInfo.CurrentRow.Selected = false;
            }

            if (e.RowIndex == 8)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Eumycota FROM botanica", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridViewInfo.DataSource = dataTable;
                this.dataGridViewInfo.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
                dataGridViewInfo.CurrentRow.Selected = false;
            }

            if (e.RowIndex == 9)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Mycobionta FROM botanica", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridViewInfo.DataSource = dataTable;
                this.dataGridViewInfo.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
                dataGridViewInfo.CurrentRow.Selected = false;
            }

            if (e.RowIndex == 10)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Bryophyta FROM botanica", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridViewInfo.DataSource = dataTable;
                this.dataGridViewInfo.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
                dataGridViewInfo.CurrentRow.Selected = false;
            }

            if (e.RowIndex == 11)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Anthocerotophyta FROM botanica", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridViewInfo.DataSource = dataTable;
                this.dataGridViewInfo.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
                dataGridViewInfo.CurrentRow.Selected = false;
            }

            if (e.RowIndex == 12)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Hepaticophyta FROM botanica", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridViewInfo.DataSource = dataTable;
                this.dataGridViewInfo.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
                dataGridViewInfo.CurrentRow.Selected = false;
            }

            if (e.RowIndex == 13)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Embryophyta FROM botanica", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridViewInfo.DataSource = dataTable;
                this.dataGridViewInfo.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
                dataGridViewInfo.CurrentRow.Selected = false;
            }

            if (e.RowIndex == 14)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Pteridophyta FROM botanica", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridViewInfo.DataSource = dataTable;
                this.dataGridViewInfo.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
                dataGridViewInfo.CurrentRow.Selected = false;
            }

            if (e.RowIndex == 15)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Spermatophyta FROM botanica", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridViewInfo.DataSource = dataTable;
                this.dataGridViewInfo.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
                dataGridViewInfo.CurrentRow.Selected = false;
            }

            if (e.RowIndex == 16)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Charophyta FROM botanica", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridViewInfo.DataSource = dataTable;
                this.dataGridViewInfo.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
                dataGridViewInfo.CurrentRow.Selected = false;
            }

            if (e.RowIndex == 17)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Cycadopsida FROM botanica", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridViewInfo.DataSource = dataTable;
                this.dataGridViewInfo.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
                dataGridViewInfo.CurrentRow.Selected = false;
            }

            if (e.RowIndex == 18)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Equisetidae FROM botanica", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridViewInfo.DataSource = dataTable;
                this.dataGridViewInfo.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
                dataGridViewInfo.CurrentRow.Selected = false;
            }

            if (e.RowIndex == 19)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Ginkgoales FROM botanica", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridViewInfo.DataSource = dataTable;
                this.dataGridViewInfo.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
                dataGridViewInfo.CurrentRow.Selected = false;
            }

            if (e.RowIndex == 20)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Gnetales FROM botanica", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridViewInfo.DataSource = dataTable;
                this.dataGridViewInfo.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
                dataGridViewInfo.CurrentRow.Selected = false;
            }

            if (e.RowIndex == 21)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Lycophyta FROM botanica", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridViewInfo.DataSource = dataTable;
                this.dataGridViewInfo.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
                dataGridViewInfo.CurrentRow.Selected = false;
            }

            if (e.RowIndex == 22)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Angiospermae FROM botanica", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridViewInfo.DataSource = dataTable;
                this.dataGridViewInfo.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
                dataGridViewInfo.CurrentRow.Selected = false;
            }

            if (e.RowIndex == 23)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Ophioglossaceae FROM botanica", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridViewInfo.DataSource = dataTable;
                this.dataGridViewInfo.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
                dataGridViewInfo.CurrentRow.Selected = false;
            }

            if (e.RowIndex == 24)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Pinidae FROM botanica", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridViewInfo.DataSource = dataTable;
                this.dataGridViewInfo.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
                dataGridViewInfo.CurrentRow.Selected = false;
            }

            if (e.RowIndex == 25)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Psilotaceae FROM botanica", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                this.dataGridViewInfo.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridViewInfo.DataSource = dataTable;
                this.dataGridViewInfo.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
                dataGridViewInfo.CurrentRow.Selected = false;
            }
        }

        private void dataGridViewInfo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Arts
            if (e.RowIndex == 0 && isClickedArts == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Arquitectura FROM artes", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedArts = false;
            }

            if (e.RowIndex == 1 && isClickedArts == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Cine FROM artes", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedArts = false;
            }

            if (e.RowIndex == 2 && isClickedArts == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Danza FROM artes", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedArts = false;
            }

            if (e.RowIndex == 3 && isClickedArts == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Literatura FROM artes", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedArts = false;
            }

            if (e.RowIndex == 4 && isClickedArts == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Musica FROM artes", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedArts = false;
            }

            if (e.RowIndex == 5 && isClickedArts == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Opera FROM artes", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedArts = false;
            }

            if (e.RowIndex == 6 && isClickedArts == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Pintura FROM artes", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedArts = false;
            }

            if (e.RowIndex == 7 && isClickedArts == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Teatro FROM artes", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedArts = false;
            }

            if (e.RowIndex == 8 && isClickedArts == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Escultura FROM artes", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedArts = false;
            }

            if (e.RowIndex == 9 && isClickedArts == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Artesania FROM artes", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedArts = false;
            }

            if (e.RowIndex == 10 && isClickedArts == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Poesia FROM artes", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedArts = false;
            }

            if (e.RowIndex == 11 && isClickedArts == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Nuevos_medios FROM artes", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedArts = false;
            }

            if (e.RowIndex == 12 && isClickedArts == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Fotografia FROM artes", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedArts = false;
            }

            if (e.RowIndex == 13 && isClickedArts == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Otras FROM artes", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedArts = false;
            }

            if (e.RowIndex == 14 && isClickedArts == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Diseño FROM artes", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedArts = false;
            }

            if (e.RowIndex == 15 && isClickedArts == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Arte FROM artes", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedArts = false;
            }

            // Science
            if (e.RowIndex == 0 && isClickedScience == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Astronomia FROM ciencias", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedScience = false;
            }

            if (e.RowIndex == 1 && isClickedScience == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Biologia FROM ciencias", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedScience = false;
            }

            if (e.RowIndex == 2 && isClickedScience == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Botanica FROM ciencias", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedScience = false;
            }

            if (e.RowIndex == 3 && isClickedScience == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Fisica FROM ciencias", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedScience = false;
            }

            if (e.RowIndex == 4 && isClickedScience == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Medicina FROM ciencias", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedScience = false;
            }

            if (e.RowIndex == 5 && isClickedScience == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Matematica FROM ciencias", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedScience = false;
            }

            if (e.RowIndex == 6 && isClickedScience == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Quimica FROM ciencias", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedScience = false;
            }

            // Society
            if (e.RowIndex == 0 && isClickedSociety == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Disciplinas FROM sociales", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedSociety = false;
            }

            if (e.RowIndex == 1 && isClickedSociety == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Comunicación FROM sociales", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedSociety = false;
            }

            if (e.RowIndex == 2 && isClickedSociety == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Deporte FROM sociales", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedSociety = false;
            }

            if (e.RowIndex == 3 && isClickedSociety == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Derecho FROM sociales", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedSociety = false;
            }

            if (e.RowIndex == 4 && isClickedSociety == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Economía FROM sociales", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedSociety = false;
            }

            if (e.RowIndex == 5 && isClickedSociety == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Filosofía FROM sociales", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedSociety = false;
            }

            if (e.RowIndex == 6 && isClickedSociety == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Lingüística FROM sociales", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedSociety = false;
            }

            if (e.RowIndex == 7 && isClickedSociety == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Psicología FROM sociales", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedSociety = false;
            }

            if (e.RowIndex == 8 && isClickedSociety == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Sociología FROM sociales", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedSociety = false;
            }

            // Religion
            if (e.RowIndex == 0 && isClickedReligion == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Religion FROM religion", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedReligion = false;
            }

            if (e.RowIndex == 1 && isClickedReligion == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Ateismo FROM religion", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedReligion = false;
            }

            if (e.RowIndex == 2 && isClickedReligion == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Budismo FROM religion", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedReligion = false;
            }

            if (e.RowIndex == 3 && isClickedReligion == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Cristianismo FROM religion", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedReligion = false;
            }

            if (e.RowIndex == 4 && isClickedReligion == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Catolicismo FROM religion", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedReligion = false;
            }

            if (e.RowIndex == 5 && isClickedReligion == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Islam FROM religion", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedReligion = false;
            }

            if (e.RowIndex == 6 && isClickedReligion == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Judaismo FROM religion", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedReligion = false;
            }

            if (e.RowIndex == 7 && isClickedReligion == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Mitologia FROM religion", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedReligion = false;
            }

            // Tecnologia
            if (e.RowIndex == 0 && isClickedTech == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Tecnología FROM tecnologia", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedTech = false;
            }

            if (e.RowIndex == 1 && isClickedTech == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Biotecnologia FROM tecnologia", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedTech = false;
            }

            if (e.RowIndex == 2 && isClickedTech == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Exploracion FROM tecnologia", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedTech = false;
            }

            if (e.RowIndex == 3 && isClickedTech == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Informatica FROM tecnologia", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedTech = false;
            }

            if (e.RowIndex == 4 && isClickedTech == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Ingenieria FROM tecnologia", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedTech = false;
            }

            if (e.RowIndex == 5 && isClickedTech == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Software FROM tecnologia", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedTech = false;
            }

            if (e.RowIndex == 6 && isClickedTech == true)
            {
                dataGridViewInfo.CurrentRow.Selected = true;
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT Videojuegos FROM tecnologia", connection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                dataGridViewInfo.DataSource = dataTable;
                dataGridViewInfo.CurrentRow.Selected = false;
                isClickedTech = false;
            }

            // Politics
        }
    }
}