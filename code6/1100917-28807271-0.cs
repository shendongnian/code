     //Web API routing configuration
        public static class WebApiConfig
        {
        	public static void Register(HttpConfiguration config)
    		{
    			// Web API configuration and services
    			// Web API routes
    			config.MapHttpAttributeRoutes();
    			config.Routes.MapHttpRoute(
    			name: "DefaultApi",
    			routeTemplate: "api/{controller}/{id}",
    			defaults: new { id = RouteParameter.Optional }
    			);
    		}
        }
        //MVC routing configuration
        public class RouteConfig
        {
    		public static void RegisterRoutes(RouteCollection routes)
    		{
    			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    			routes.MapRoute(
    			name: "Default",
    			url: "{controller}/{action}/{id}",
    			defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
    			);
    		}
        }
   
