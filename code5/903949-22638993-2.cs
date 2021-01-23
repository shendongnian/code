        using System.IdentityModel.Services;
         using System.IdentityModel.Services.Configuration;
        public class MvcApplication : HttpApplication
        {
            protected void Application_Start()
          {
              AreaRegistration.RegisterAllAreas();
              RouteConfig.RegisterRoutes(RouteTable.Routes);
                FederatedAuthentication.FederationConfigurationCreated += FederatedAuthentication_FederationConfigurationCreated;
          }
        private static void FederatedAuthentication_FederationConfigurationCreated(object sender, FederationConfigurationCreatedEventArgs e)
        {
            //from appsettings...
            const string domain = "";
            const bool requireSsl = false;
            const string authCookieName = "YourSiteAuth"; //default is fedauth, i normally create my own name as it is easier to identify when you have a lot of cookies.
            e.FederationConfiguration.CookieHandler = new ChunkedCookieHandler
                {
                    Domain = domain,
                    Name = authCookieName,
                    RequireSsl = requireSsl,
                    PersistentSessionLifetime = new TimeSpan(0, 0, 30, 0)
                };
        }
