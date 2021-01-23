    public async Task<ClaimsIdentity> GenerateUserIdentityAsync()
	{
    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			
			var userIdentity = await AuthServerProxy.CreateIdentityAsync(DefaultAuthenticationTypes.ApplicationCookie);
			// Add custom user claims here
			return userIdentity;
		}    
