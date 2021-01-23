    static void Main()
    {
        //Auto-generated code that VS writes for you
        
        using (var loginForm = new LoginForm())
        {
            if (loginForm.ShowDialog() == DialogResult.Yes) //Presumably it would only return Yes if the login was successful.
            {
                Application.Run(new MainForm()); //Or however you call your main form
            }
        }
    }
