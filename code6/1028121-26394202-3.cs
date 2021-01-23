        private void txtxPassword_KeyUp(object sender, KeyEventArgs e)
        {
            var pass = txtxPassword.Text;
            if (pass.Length < 1)
                realPass = string.Empty;
            else
                realPass += pass[pass.Length - 1];
            if (e.KeyCode == Keys.Back)
            {
                if (realPass.Length <= 1)
                    realPass = "";
                else
                {
                    realPass = realPass.Substring(0, realPass.Length - 2);
                }
            }
            string result = "";
            if (realPass != string.Empty)
            {
                
                for (var i = 0; i < realPass.Length - 1; i++)
                {
                    result += "X";
                }
                result += realPass[realPass.Length - 1];
            }
                txtxPassword.Text = result;
                txtxPassword.SelectionStart = result.Length;
                lblpass.Text = realPass;
            }
        private void txtxPassword_Leave(object sender, EventArgs e)
        {
            string result="";
            for (var i = 0; i < realPass.Length ; i++)
                {
                    result += "X";
                }
            txtxPassword.Text = result;
            lblpass.Text = realPass;
        }
