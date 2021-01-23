    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
    {
        // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        
        // Add claim for tenant name
        userIdentity.AddClaim(new Claim("tenantName", "abcCompany");
        // Add custom user claims here
        return userIdentity;
    }
