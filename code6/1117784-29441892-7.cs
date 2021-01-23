    public static class WebApiConfig
    {
        public static ObservableDirectRouteProvider GlobalObservableDirectRouteProvider = new ObservableDirectRouteProvider();
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Web API routes
            config.MapHttpAttributeRoutes(GlobalObservableDirectRouteProvider);
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
