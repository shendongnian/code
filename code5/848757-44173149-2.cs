    public static void Register(HttpConfiguration config)
    {
        config.MapHttpAttributeRoutes();
    
        config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { controller = "WebApi", id = RouteParameter.Optional }
        );
    
        //FOR User JSON format
        config.Formatters.Remove(config.Formatters.XmlFormatter);
        config.Formatters.JsonFormatter.SupportedMediaTypes.Add(
            new MediaTypeHeaderValue("application/json")
        );
    }
