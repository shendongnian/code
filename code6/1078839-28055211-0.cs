        private void buttonClose_Click(object sender, EventArgs e)
        {
            ExceptionLoggingService.Instance.WriteLog("Reached frmLogin.buttonClose_Click");
            this.DialogResult = DialogResult.Cancel; 
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            ExceptionLoggingService.Instance.WriteLog("Reached frmLogin.buttonOK_Click");
            if (SanityCheck())
            {
                this.DialogResult = DialogResult.OK; 
            }
            else
            {
                MessageBox.Show("You have not yet provided some key data; be sure to enter a username and a password");
            }
        }
