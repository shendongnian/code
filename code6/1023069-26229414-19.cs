    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        LogonForm form = new LogonForm();
   
        if (form.ShowDialog() != DialogResult.OK)
        {
            //Handle authentication failures as necessary, for example:
            Application.Exit();
        }
        else
        {
            Application.Run(new Form2());
        }
    }
