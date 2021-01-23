    public static class WebApiConfig
    {
        /// <summary>
        /// Register the http configuration for web API.
        /// </summary>
        /// <param name="config">The http configuration instances</param>
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            
        }
    }
