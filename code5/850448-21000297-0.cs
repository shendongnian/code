    class MainForm : Form
    {
        string username;
        string password;
        public MainForm(string username, string password)
        {
            InitializeComponent();
            // set field values
            this.username = username;
            this.password = password;
        }
    
        void settingButton_Click(object o, EventArgs args)
        {
            // get field values
            frmSetting _settings = new frmSetting(this.username, this.password);
            _settings.Show();
        }
    }
