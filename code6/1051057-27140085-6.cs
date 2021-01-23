        SessionStateSection sessionStateSection = ConfigurationManager.GetSection("system.web/sessionState") as SessionStateSection;
        app.UseCookieAuthentication(new CookieAuthenticationOptions
        {
            AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            LoginPath = new PathString("/account/login"),
            CookieName = sessionStateSection.CookieName + "_Application",
            Provider = new CookieAuthenticationProvider
            {
                // Enables the application to validate the security stamp when the user logs in.
                OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser, int>
                    (
                         validateInterval: TimeSpan.FromMinutes(30),
                         regenerateIdentityCallback: (manager, user) => user.GenerateUserIdentityAsync(manager),
                         getUserIdCallback: (id) => (id.GetUserId<int>())
                    ) 
            }
        });
