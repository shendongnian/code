    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            // you can add manual routes as well
            //config.Routes.MapHttpRoute(...
        }
    }
