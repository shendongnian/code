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
        }
