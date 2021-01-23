    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
    
            config.Routes.MapHttpRoute(
                name: "DefaultVideo",
                routeTemplate: "api/{controller}/{ext}/{filename}"
            );
            config.EnableSystemDiagnosticsTracing();
        }
    }
