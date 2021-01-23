    [assembly: OwinStartup(typeof(Yugasat.System.ServiceLayer.Startup))]
    namespace Yugasat.System.ServiceLayer
    {
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                ConfigureOAuth(app);
                var config = new HttpConfiguration();
                WebApiConfig.Register(config);
                app.UseWebApi(config);
                var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
                jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            }
            private void ConfigureOAuth(IAppBuilder app)
            {
                var oAuthServerOptions = new OAuthAuthorizationServerOptions()
                {
                    AllowInsecureHttp = true,
                    TokenEndpointPath = new PathString("/Token"),
                    AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                    Provider = new DefaultAuthorizationServerProvider()
                };
                app.UseOAuthAuthorizationServer(oAuthServerOptions);
                app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            }
        }
    }
