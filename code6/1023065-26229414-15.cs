    private void Login()
    {
        if (CheckCredentials())
        {
            this.DialogResult = DialogResult.OK;
        }
        else
        {
            MessageBox.Show("Please enter correct credentials and try again!");
        }
    }
    
    private void BtnLogin_Click(object sender, EventArgs e)
    {
        Login();
    }
