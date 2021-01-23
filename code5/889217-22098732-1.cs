    public bool Login(string userName, string password)
    {
        var provider = Membership.Provider;
        string name = provider.ApplicationName; // Get the application name here
        return Membership.ValidateUser(userName, password);
    }
