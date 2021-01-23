    if (String.IsNullOrWhitespace(Properties.Settings.Default.UserName))
    {
        // USER NEEDS TO LOG IN
        string userName;
        string password;
        if (Login(out userName, out password))
        {
            try
            {
                Properties.Settings.Default.UserName = Encrypt(userName);
                Properties.Settings.Default.Password = Encrypt(password);
                Properties.Settings.Default.Save();
            }
            catch (Exception exp)
            {
                ...
            }
        }
    }
    else
    {
        // USER IS ALREADY LOGGED IN
    }
