    // set up domain context
    using (var ctx = new PrincipalContext(ContextType.Domain))
    // find a user
    using (var user = UserPrincipal.FindByIdentity(ctx, "SomeUserName"))
    {
        if (user != null)
        {
           // get the user's groups
           var groups = user.GetAuthorizationGroups();
           
           foreach (var group in groups)
           {
               // do whatever you need to do with those groups
           }
        }
    }
