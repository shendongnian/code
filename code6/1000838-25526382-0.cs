    public bool Authenticate(string username, string password)
    {
        var authenticated = FormsAuthentication.Authenticate(username, password);
        if (authenticated)
            FormsAuthentication.SetAuthCookie(username, false);
        return authenticated:
    }
