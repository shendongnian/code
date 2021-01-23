    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ConfigureODataRoutes(config);
            ConfigureWebApiRoutes(config);
        }
        private static void ConfigureWebApiRoutes(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
        }
        private static void ConfigureODataRoutes(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Formatters.Insert(0, new JsonDotNetFormatter());
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<...>("<myendpoint>");
            ...
            config.MapODataServiceRoute("ODataRoute", "odata", builder.GetEdmModel());
        }
    }
