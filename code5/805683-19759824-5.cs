    private async Task LoginAsync(IdentityUser user, ClaimsIdentity identity)
    {
        AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        // I can't just use the identity I got on Facebook
        // I need to create this one, or else it will not signin properly
        // The authentication type has to be ApplicationCookie and the property
        // is readonly, so...
        var userIdentity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
        // now we have to transfer the claims, adding a check to avoid duplicates
        foreach (var claim in identity.Claims)
        {
            if (!userIdentity.HasClaim(c => c.Type == claim.Type))
                userIdentity.AddClaim(claim);
        }
        // then it will signin successfully
        AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, userIdentity);
    }
