    // 1. 
    IdentityResult result = manager.Create(user, "Password134567");
    if (result.Succeeded)
    {
        var provider = new DpapiDataProtectionProvider("WebApp2015");
        manager.UserTokenProvider = 
            new DataProtectorTokenProvider<User>(provider.Create(user.Id));
        
        // 3.
        var provider = provider.Create("ConfirmUser");
        manager.UserTokenProvider = 
            new DataProtectorTokenProvider<User>(provider);
        
        // 4. 
        string raw = manager.GenerateEmailConfirmationToken(user.Id);
        string code = HttpUtility.UrlEncode(raw);
 
        // 5. 
        string callbackUrl = IdentityHelper
            .GetUserConfirmationRedirectUrl(code, user.Id, Request);
    
        // remaining code removed
    }
