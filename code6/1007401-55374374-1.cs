    app.UseCookieAuthentication(new CookieAuthenticationOptions
                        { 
                            AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                            SlidingExpiration = true,
                            CookieHttpOnly = false,
                            LoginPath = new PathString("/Account/Login"),
        
                            Provider = new CookieAuthenticationProvider
                            {  
                                OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                                validateInterval: TimeSpan.FromMinutes(30),
            
                                    regenerateIdentity: (manager, user) => 
                                    user.GenerateUserIdentityAsync(manager)),
                               
                                OnResponseSignIn = context => {
                                    context.Properties.IsPersistent = true; };
                                } 
            }
