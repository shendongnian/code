    // 1. 
    IdentityResult result = manager.Create(user, "Password134567");
    if (result.Succeeded)
    {
        var provider = new DpapiDataProtectionProvider("WebApp2015");
        // 2. 
        UserManager<User> userManager = 
            new UserManager<User>(new UserStore<User>());
        userManager.UserTokenProvider = 
            new DataProtectorTokenProvider<User>(provider.Create(user.Id));
        
        // 3.
        manager.UserTokenProvider = 
            new DataProtectorTokenProvider<User>(provider.Create("ConfirmUser"));
        
        // 4. 
        string raw = Context.GetOwinContext()
                     .GetUserManager<ApplicationUserManager>()
                     .GenerateEmailConfirmationToken(user.Id)
        // remaining code removed
    }
