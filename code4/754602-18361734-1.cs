    private void frmMyForm_Load(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(Settings.Default.Username))
        {
            //start you application and bypass login
        }
        else
        {
            //show login form
        }
    }
