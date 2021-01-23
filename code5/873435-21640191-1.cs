    private void formMain_Load(object sender, EventArgs e)
    {
        if (Environment.GetCommandLineArgs().Length > 1)
        {
            // The first command line argument is the application path
            // The second command line argument is the first argument passed to the application
            tWSID.Text = Environment.GetCommandLineArgs()[1];
        }
    }
