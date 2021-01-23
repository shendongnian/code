    private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtPassword.ForeColor = Color.Black;
            txtPassword.UseSystemPasswordChar = true;
        }
        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length == 0)
            {
                txtPassword.ForeColor = Color.Gray;
                txtPassword.Text = "Enter password";
                txtPassword.UseSystemPasswordChar = false;
                SelectNextControl(txtPassword, true, true, false, true);
            }
        }
