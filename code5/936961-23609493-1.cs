    private void frmMain_Load(object sender, EventArgs e)
    {
         // initialization of fields in frmMain
         .
         .
        if (Program.autoStart)
        {
            MailSend();
            Application.Exit();
        }
    }
    
    
