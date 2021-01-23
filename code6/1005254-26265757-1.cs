    public void Configuration(IAppBuilder app)
    {
        app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
        
        app.UseCookieAuthentication(new CookieAuthenticationOptions());
        app.UseWsFederationAuthentication(new WsFederationAuthenticationOptions
        {
            AuthenticationType = "WS-Fed Auth (Primary)",
            Wtrealm = ConfigurationManager.AppSettings["app:URI"],
            MetadataAddress = ConfigurationManager.AppSettings["wsFederation:MetadataEndpoint"]
        });
        AuthenticateAllRequests(app, "WS-Fed Auth (Primary)");
        app.UseWelcomePage();
    }
