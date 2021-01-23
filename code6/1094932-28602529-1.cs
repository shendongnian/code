    public static OAuthBearerAuthenticationOptions OAuthServerOptions { get; private set; }       
        public void ConfigureOAuth(IAppBuilder app)
        {
            
            // Configure the db context, the user manager, and the login manager to use a single instance per request.
            app.CreatePerOwinContext(ApplicationDbContext.Create);           
            // Token Generation
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(20),
                Provider = new AuthorizationServerProvider()
            };
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            
            // Enable application to use a cookie to store information for the logged-on user     
            // and to use a cookie to temporarily store information about a user who logs in with the third-party logon provider.
            // Configure the login cookie.
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                CookieSecure = CookieSecureOption.SameAsRequest,                     
                ExpireTimeSpan = new TimeSpan(0, 20, 0),
                SlidingExpiration = true,
                Provider = new CookieAuthenticationProvider
                {
                    
                    // Enables the application to check the security stamp when the user logs on.   
                    // This is a security feature that is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(20),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            // Enables the application to temporarily store user information when checking the second level in the two-step authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));
            // Enables the application to store the second login verification level (for example, phone or email).
            // If you enable this option, your second verification step is saved on the device from which you logged on during the login process.
            // This is similar to the RememberMe option when logging in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);
        }      
