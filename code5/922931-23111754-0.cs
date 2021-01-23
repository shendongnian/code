    // set up domain context
    using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain))
    {
        // find a user
        UserPrincipal user = UserPrincipal.FindByIdentity(ctx, "SomeUserName");
    
        if(user != null)
        {
           bool isActive = user.Enabled;
        }
    }
