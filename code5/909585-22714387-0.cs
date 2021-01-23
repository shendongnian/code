    public bool Login()
    {
        var username = Properties.Settings.Default["Username"];
        var password = Properties.Settings.Default["Password"];
        if (username == null || password == null)
        {
            // Ask the user to login
            var user = LoginWindow.AskForLogin();
            // If user login
            if (user != null)
            {
                username = user.Username;
                password = user.Password;
                Properties.Settings.Default["Username"] = username;
                Properties.Settings.Default["Password"] = password;
            }
        }
        // Log your user
        return Authenticate(username, password);
    }
