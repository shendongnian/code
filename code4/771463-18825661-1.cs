        using System.Web.Http;
        public class MvcApplication : System.Web.HttpApplication
        {
            protected void Application_Start()
            {
                GlobalConfiguration.Configuration.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = System.Web.Http.RouteParameter.Optional }
                );
            }
        }
