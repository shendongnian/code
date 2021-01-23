        public partial class LoginForm : Form
    {
        
    
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            //check username password
            if(texboxUser == "user" && texboxPassword == "password")
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Wrong user pass");
            }
        }
    }
