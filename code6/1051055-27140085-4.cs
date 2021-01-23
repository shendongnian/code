    public static ApplicationUser GetApplicationUser(this System.Security.Principal.IIdentity identity)
    {
        if (identity.IsAuthenticated)
        {
            using (var db = new AppContext())
            {
                var userManager = new ApplicationUserManager(new ApplicationUserStore(db));
                return userManager.FindByName(identity.Name);
            }
        }
        else
        {
            return null;
        }        
    }
