    // set up domain context and bind to the OU=Test container
    using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "YOURDOMAIN", "OU=TEST"))
    {
        // create a new user
        UserPrincipal user = new UserPrincipal(ctx);
        // set first name, last name, display name, SAM Account Name and other properties easily
        user.DisplayName = "Artemij Voskobojnikov";
        user.GivenName = "Artemij";
        user.Surname = "Voskobojnikov";
        user.SamAccountName = "AVoskobojnikov";
 
        // set some flags as appropriate for your use
        user.UserCannotChangePassword = true;
        user.PasswordNeverExpires = true;
        // save user
        user.Save();
    }
