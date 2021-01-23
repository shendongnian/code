    var authHandler = this.HttpContext.RequestServices.GetRequiredService<IAuthenticationHandlerProvider>();
    var h = await authHandler.GetHandlerAsync(this.HttpContext, IdentityConstants.ExternalScheme);
    var a = await h.AuthenticateAsync();
    var externalLoginInfo = await this.SignInManager.GetExternalLoginInfoAsync();
    
