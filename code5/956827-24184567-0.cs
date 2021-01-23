    public partial class Login : Form
    {
        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
        loginInfo.username = txtUsername.Text;
        loginInfo.password = txtPassword.Text;
        //do some other task with username & password
        }
        public static class loginInfo
        {
            public static string username;
            public static string password;
        }
    }
