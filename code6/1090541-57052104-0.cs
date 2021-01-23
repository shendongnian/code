    PrincipalContext ctx;
    
    if(this.UserEntityContext.IsLocalLogin == true)
    {
    	ctx = new PrincipalContext(ContextType.Machine);
    }
    else
    {
    	ctx = new PrincipalContext(ContextType.Domain);
    }
    UserPrincipal currentUser = UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, _userInfo.UserID);
    
    PrincipalSearchResult<Principal> groups = currentUser.GetAuthorizationGroups();
