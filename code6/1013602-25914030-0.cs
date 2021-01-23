    var success = Sitecore.Security.Authentication.AuthenticationManager.Login(userName, false);
    if (!success)
    {
        // Handle login failure.
    }
