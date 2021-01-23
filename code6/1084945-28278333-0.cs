    // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
    public void ConfigureAuth(IAppBuilder app)
    {
        // Configure the db context and user manager to use a single instance per request
        app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
        // Enable the application to use a cookie to store information for the signed in user
        // and to use a cookie to temporarily store information about a user logging in with a third party login provider
        app.UseCookieAuthentication(new CookieAuthenticationOptions());
        app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
        // Configure the application for OAuth based flow
        PublicClientId = "self";
        OAuthOptions = new OAuthAuthorizationServerOptions
        {
            TokenEndpointPath = new PathString("/api/Token"),
            Provider = new ApplicationOAuthProvider(PublicClientId),
            AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
            AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
            AllowInsecureHttp = true
        };
        // Enable the application to use bearer tokens to authenticate users
        app.UseOAuthBearerTokens(OAuthOptions);
    }
