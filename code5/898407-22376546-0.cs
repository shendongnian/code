    private bool ValidateForm()
    {
        bool isvalidate = true;
    
        try
        {
            string username = this.txtUsername.Text;
            string password = this.txtPassword.Text;
    
            if (username == "" || username == string.Empty)
            {
                this.labelMessage.Text = "Please enter username";
                ScriptManager.GetCurrent(this.Page).SetFocus(this.txtUsername);
                isvalidate = false;
            }
            else if (password == "" || password == string.Empty)
            {
                this.labelMessage.Text = "Please enter password";
                ScriptManager.GetCurrent(this.Page).SetFocus(this.txtPassword);
                isvalidate = false;
            }
        }
        catch (Exception ex)
        {
            Monitoring.WriteException(ex);
        }
        return isvalidate;
    }
