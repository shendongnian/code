    // assume you already have references to a UserManager and HttpContext
    var userToImpersonate = await userManager
        .FindByNameAsync(userNameToImpersonate);
    var identityToImpersonate = await userManager
        .CreateIdentityAsync(userToImpersonate,   
            DefaultAuthenticationTypes.ApplicationCookie);
    var authenticationManager = httpContext.GetOwinContext().Authentication;
    authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
    authenticationManager.SignIn(new AuthenticationProperties()
    {
        IsPersistent = false
    }, identityToImpersonate);
