    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Login login = new Login();
        if (login.ShowDialog() != DialogResult.OK)
            return;
        var user = login.User;
        Form mainForm = user.IsAdmin ? (Form)new Admin() : new UserForm(user.Name);
        Application.Run(mainForm);
    }
