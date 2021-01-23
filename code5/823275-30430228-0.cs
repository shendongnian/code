    public void ConfigureOAuth(IAppBuilder app)
            {
                app.UseCors(CorsOptions.AllowAll);
    
                OAuthAuthorizationServerOptions serverOptions = new OAuthAuthorizationServerOptions()
                {
                    AllowInsecureHttp = true,
                    TokenEndpointPath = new Microsoft.Owin.PathString("/token"),
                    AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                    AuthenticationType = AuthenticationTypes.Password,
                    AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
                    Provider = new AppAuthServerProvider()
                };
    
    
                app.UseOAuthAuthorizationServer(serverOptions);
                app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions()
                    {
                        AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
                        AuthenticationType = AuthenticationTypes.Password
                    });            
            }
