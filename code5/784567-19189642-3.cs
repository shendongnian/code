    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        LoginForm loginForm = new LoginForm();
        Application.Run(loginForm);
        if (loginForm.DialogResult == DialogResult.OK)
        {
            Application.Run(new MainForm());
        }
        else
        {
            // Error handling
        }
    }
