    PrincipalContext ctx = new PrincipalContext(ContextType.Machine);
    
    UserPrincipal usr = UserPrincipal.FindByIdentity(ctx, 
                                               IdentityType.SamAccountName, 
                                               "Guest");
    
    if(usr != null)
    {
        if (usr.Enabled == false)
            usr.Enabled = true;
    
        usr.Save();
        usr.Dispose();
    }
    ctx.Dispose(); 
