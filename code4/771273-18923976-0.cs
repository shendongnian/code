    public void Configuration(IAppBuilder app)
    {
        var config = new HttpConfiguration();
        config.SuppressDefaultHostAuthentication();
        config.Filters.Add(new HostAuthenticationFilter(Startup.OAuthOptions.AuthenticationType));
    
        config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    
        config.MapHttpAttributeRoutes();
    
        app.UseCookieAuthentication(CookieOptions);
    
        app.UseExternalSignInCookie(ExternalCookieAuthenticationType);
    
        app.UseOAuthBearerTokens(OAuthOptions, ExternalOAuthAuthenticationType);
    
        app.UseFacebookAuthentication(
            appId: "123456",           // obviously changed for this post
            appSecret: "deadbeef");    // obviously changed for this post
    
        app.UseWebApi(config);
    }
