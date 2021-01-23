    var fullName = string.Empty;
    using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
    {
    	using (UserPrincipal user = UserPrincipal.FindByIdentity(context,"racerX")) //User.Identity.Name
    	{
    		if (user != null)
    		{
    			fullName = user.DisplayName;
    		}
    	}
    }
