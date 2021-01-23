    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.ApplicationAuthenticationType);
    identity.AddClaim(new Claim(ClaimTypes.Name, "Test"));
    AuthenticationManager.AuthenticationResponseGrant = new AuthenticationResponseGrant(identity, new AuthenticationProperties()
    {
        IsPersistent = true
    });
