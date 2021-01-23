    [AllowAnonymous]
    public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
    {
        ClaimsIdentity identity = await AuthenticationManager.GetExternalIdentityAsync(DefaultAuthenticationTypes.ExternalCookie);
        var user = new IdentityUser()
        {
            Id = identity.GetUserId(),
            UserName = identity.Name,
        };
        await LoginAsync(user, identity);
        if (!identity.IsAuthenticated)
        {
            return RedirectToAction("Login");
        }
        return RedirectToAction("Index", "Home");
    }
