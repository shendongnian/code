    public void ConfigureAuth(IAppBuilder app)
    {
        // important to register UserManager creation delegate. Won't work without it
        app.CreatePerOwinContext(UserManager.Create);
    
        app.UseCookieAuthentication(new CookieAuthenticationOptions
        {
            Provider = new CookieAuthenticationProvider
            {
                OnValidateIdentity = SecurityStampValidator
                    .OnValidateIdentity<UserManager, ApplicationUser, int>(
                        validateInterval: TimeSpan.FromMinutes(10),
                        regenerateIdentityCallback: (manager, user) => user.GenerateUserIdentityAsync(manager))
            },
            // other configurations
        });
    
        // other stuff
    }
