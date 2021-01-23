    app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => {
                            var identity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                            //some additional claims and stuff specific to my needs
                            return Task.FromResult(identity);
                        })
                },
                CookieDomain = ".example.com"
            });
