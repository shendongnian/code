    userManager.UserTokenProvider = 
        new DataProtectorTokenProvider<User>(provider.Create(user.Id));
    
    manager.UserTokenProvider = 
        new DataProtectorTokenProvider<User>(provider.Create("ConfirmUser"));
    string code = Context
        .GetOwinContext()
        .GetUserManager<ApplicationUserManager ()      
        .GenerateEmailConfirmationToken(user.Id)
