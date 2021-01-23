    void StoreLoginCredentials(string password)
    {
        var userDetails = NSUserDefaults.StandardUserDefaults;
        userDetails.SetString(password, "password");
        userDetails.Synchronize();
    }
    
    bool CheckUserSession()
    {
        var userDetails = NSUserDefaults.StandardUserDefaults;
        return userDetails["password"] != null;
    }
    
    bool DestroyLoginCredentials()
    {
        var defaults = NSUserDefaults.StandardUserDefaults;
        defaults.RemovePersistentDomain(NSBundle.MainBundle.BundleIdentifier);
        return defaults.Synchronize();
    }
    
    string PasswordOfUser()
    {
        var userDetails = NSUserDefaults.StandardUserDefaults;
        return userDetails["password"];
    }
