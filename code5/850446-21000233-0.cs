    public class Credentials : EventArgs {
		public string User { get; set; }
		public string Password { get; set; }
    }
    public MainForm(string username, string password)
    {
        InitializeComponent();
        var cred = new Credentials(){User = username, Password = password};
        settingButton_Click(this, cred);
    }
        private void settingButton_Click(object sender, EventArgs e)
        {
	     	var cred = (Credentials)e;
	     	frmSetting _settings = new frmSetting(cred.User, cred.Password);
            _settings.Show();   
        }
