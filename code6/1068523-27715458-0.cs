    public void ConfigureAuth(IAppBuilder app)
            {
                Func<CookieResponseSignInContext, Task> asyncFunc = async ctx =>
                {
                    var claims = await GetClaims(ctx.Identity.Name);
                    ctx.Identity.AddClaims(claims);
                };
    
                app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/Account/Login"),
                    Provider = new CookieAuthenticationProvider
                    {
                        // Enables the application to validate the security stamp when the user logs in.
                        // This is a security feature which is used when you change a password or add an external login to your account.  
                        OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                           validateInterval: TimeSpan.FromMinutes(30),
                           regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager)),
                        OnResponseSignIn = context =>
                        {
                            asyncFunc(context);
                        }
                    }
                });
               .....
    }
