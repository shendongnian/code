        private void btnLogin_Click(object sender, EventArgs e)
        {
            var login = new LoginForm();
            login.ShowDialog();
            var result = login.DialogResult == System.Windows.Forms.DialogResult.Yes;
            if (result)
            {
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }
