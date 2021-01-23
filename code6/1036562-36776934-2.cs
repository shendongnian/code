    app.Map("/signalr", map =>
        {
            map.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions()
            {
                Provider = new QueryStringOAuthBearerProvider() //important bit!
            });
            var hubConfiguration = new HubConfiguration
            {
                EnableDetailedErrors = true,
                Resolver = GlobalHost.DependencyResolver,
            };
            map.RunSignalR(hubConfiguration);
        });
