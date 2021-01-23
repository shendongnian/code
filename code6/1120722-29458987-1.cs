    app.UseCookieAuthentication(new CookieAuthenticationOptions
    {
        ExpireTimeSpan = System.TimeSpan.FromDays(30),
        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
        Provider = new CookieAuthenticationProvider
        {                           
            OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                validateInterval: TimeSpan.FromMinutes(30),
                regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
        }
    });
