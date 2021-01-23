    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // configure the rest of the services/formatters
            // Web API routes
            config.MapHttpAttributeRoutes();
        }
    }
