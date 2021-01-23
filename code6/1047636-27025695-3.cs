    MainForm : Form {
        private void AddButton_Click(object sender, EventArgs e) {
            //NewPasswordForm newPassword = new NewPasswordForm(); // Don't need this line
            using (NewPasswordForm form = new NewPasswordForm())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Console.WriteLine("Made it work");
                    Login login = form.LoginInfo;
                    // do something
                }
            }            
        }
    }
