    [AuthenticateAdmin] // <- make sure this endpoint is only available to admins
    public async Task ImpersonateUserAsync(string userName)
    {
        var context = HttpContext.Current;
    
        var originalUsername = context.User.Identity.Name;
    
        var impersonatedUser = await userManager.FindByNameAsync(userName);
    
        var impersonatedIdentity = await userManager.CreateIdentityAsync(impersonatedUser, DefaultAuthenticationTypes.ApplicationCookie);
        impersonatedIdentity.AddClaim(new Claim("UserImpersonation", "true"));
        impersonatedIdentity.AddClaim(new Claim("OriginalUsername", originalUsername));
    
        var authenticationManager = context.GetOwinContext().Authentication;
        authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, impersonatedIdentity);
    }
