    private bool SiteSpecificAuthenticationMethod(string UserName, string Password)
    {
        // Insert code that implements a site-specific custom 
        // authentication method here.
        //
        // This example implementation always returns false.
        return false;
    }
    
    private void OnAuthenticate(object sender, AuthenticateEventArgs e)
    {
        bool Authenticated = false;
        Authenticated = SiteSpecificAuthenticationMethod(Login1.UserName, Login1.Password);
    
        e.Authenticated = Authenticated;
    }
