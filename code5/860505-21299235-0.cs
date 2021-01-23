        private void frmMain_Load(object sender, EventArgs e)
        {
            //Check login
            Form frmLogin = new Form();
            frmLogin.ShowDialog();
            if (frmLogin.LoginSucessful == true)
            {
                btnRecords.Enabled = true;
                lblWarning.Visible = false;
            }
            else
            {
                btnRecords.Enabled = false;
                lblWarning.Visible = true;
                lblWarning.Text = "You must first Login";
            }
            //other setup code here
        }
