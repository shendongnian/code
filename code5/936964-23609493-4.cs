    private void frmMain_Load(object sender, EventArgs e)
    {
         // Initialization of fields in frmMain
         .
         .
        if (Program.autoStart)
        {
            MailSend();
            Application.Exit();
        }
    }
