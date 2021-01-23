    public static void MapAttributeRoutes(...)
    {
        RouteCollectionRoute aggregateRoute = new RouteCollectionRoute();
        configuration.Routes.Add(AttributeRouteName, aggregateRoute);
        ...
        Action<HttpConfiguration> previousInitializer = configuration.Initializer;
        configuration.Initializer = config =>
        {
            previousInitializer(config);
            ...
        };
    }
