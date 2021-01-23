    public static void Register(HttpConfiguration config)
            {
                // Web API configuration and services
    
                // Web API routes
    
                var cors = new EnableCorsAttribute(
                    origins: "*",
                    headers: "*",
                    methods: "*");
                config.EnableCors(cors);
    
                config.MapHttpAttributeRoutes();
    
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
            }
