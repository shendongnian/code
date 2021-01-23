    public static void Register(HttpConfiguration config) {
        config.MapHttpAttributeRoutes
        config.Routes.MapHttpRoute(
            name: "CatchAll", routeTemplate: "values/path/{*pathvalue}", 
            defaults: new {id = RouteParameter.Optional });
    }
