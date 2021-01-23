    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        using(LoginForm loginForm = new LoginForm())
        {
            if (loginForm.ShowDialog() != DialogResult.OK)
                return; // exit applicatioin if login failed
        }
        // if login successfully this start main form
        Application.Run(new Smart_Pharmacy());
    }
      
