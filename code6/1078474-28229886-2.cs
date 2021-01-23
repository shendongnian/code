    public static void Register(HttpConfiguration config)
        {
            config.Routes.MapODataRoute(
            routeName: "OData1",
            routePrefix: "odata1",
            model: ModelBuilder.GetModal1());
    
            config.Routes.MapODataRoute(
            routeName: "OData2",
            routePrefix: "odata2",
            model: ModelBuilder.GetModal2());
        }
