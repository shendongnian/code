    public static void UseOAuthBearerTokens(this IAppBuilder app, OAuthAuthorizationServerOptions options)
            {
                if (app == null)
                {
                    throw new ArgumentNullException("app");
                }
                if (options == null)
                {
                    throw new ArgumentNullException("options");
                }
    
                app.UseOAuthAuthorizationServer(options);
    
                app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
                {
                    AccessTokenFormat = options.AccessTokenFormat,
                    AccessTokenProvider = options.AccessTokenProvider,
                    AuthenticationMode = options.AuthenticationMode,
                    AuthenticationType = options.AuthenticationType,
                    Description = options.Description,
                    Provider = new ApplicationOAuthBearerProvider(),
                    SystemClock = options.SystemClock
                });
    
                app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
                {
                    AccessTokenFormat = options.AccessTokenFormat,
                    AccessTokenProvider = options.AccessTokenProvider,
                    AuthenticationMode = AuthenticationMode.Passive,
                    AuthenticationType = DefaultAuthenticationTypes.ExternalBearer,
                    Description = options.Description,
                    Provider = new ExternalOAuthBearerProvider(),
                    SystemClock = options.SystemClock
                });
            }
