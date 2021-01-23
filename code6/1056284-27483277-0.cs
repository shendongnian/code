    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "Route1",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
    
            config.Routes.MapHttpRoute(
                name: "Route2",
                routeTemplate: "api2/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: null,
                handler: new CustomCertificateMessageHandler()  // per-route message handler
            );
    
            config.MessageHandlers.Add(new SomeOtherMessageHandler());  // global message handler
        }
    }
