    private void showSettings(string user, string pass) {
        frmSetting _settings = new frmSetting(user, pass);
        _settings.Show();
    }
    private void settingButton_Click(object sender, EventArgs e) {
        string user = ... ,
            pass = ... ;
        showSettings(user, pass);
    }
    public MainForm(string username, string password)
    {
        InitializeComponent();
        showSettings(username, password);
    }
