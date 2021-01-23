    public override async Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
    {
        var externalIdentity = await AuthenticationManager.GetExternalIdentityAsync(DefaultAuthenticationTypes.ExternalCookie);
    
        var localIdentity = await user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
    
        foreach (var item in externalIdentity.Claims)
        {
            if (!localIdentity.HasClaim(o => o.Type == item.Type))
                localIdentity.AddClaim(item);
        }
    
        return localIdentity;
    }
