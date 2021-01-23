    public static void Register(HttpConfiguration config)
    {
        // Web API routes
        config.MapHttpAttributeRoutes();
        config.Services.Add(typeof(IExceptionLogger), new ElmahExceptionLogger());
    }
