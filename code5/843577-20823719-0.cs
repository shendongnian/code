    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Login login = new Login();
        if (login.ShowDialog() != DialogResult.OK)
            return;
        Application.Run(new UserForm(login.UserName));
    }
   
