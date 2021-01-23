    // set up domain context
    using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain))
    {
        // find a user
        UserPrincipal user = UserPrincipal.FindByIdentity(ctx, _userName);
    
        if(user != null)
        {
           // get the GUID
           var objectGuid = user.Guid;
        }
    }
