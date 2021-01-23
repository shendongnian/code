    private void formMain_Load(object sender, EventArgs e)
    {
        if (Environment.GetCommandLineArgs().Length > 1)
        {
            // The first command line arg is the application path
            // The second command line ar
            tWSID.Text = Environment.GetCommandLineArgs()[1];
        }
    }
