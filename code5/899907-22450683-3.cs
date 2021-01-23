    public class Users
    {
        public string GetUserType(string username, string password)
        {
            // ...
        }
    }
    public partial class LogIn : Form
    {
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            User user = new User();
            if (Array.IndexOf(
                new string[] { "Administrator", "Staff", "Student" },
                Contains(GetUserType(txtUsername.Text, txtPassword.Text).Equals(true),
                >= 0))
            {
                Enrollment enroll = new Enrollment();
                MessageBox.Show("Successfully Log In", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                enroll.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Clear();
                txtPassword.Clear();
                txtUsername.Focus();
            }
        }
    }
