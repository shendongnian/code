    Dictionary<string, object> constraints = new Dictionary<string, object>();
    // populate your constraints into the constraints dictionary here..
    Dictionary<string, object> dataTokens = new Dictionary<string, object>();
    Dictionary<string, object> defaults = new Dictionary<string, object>();
    Route route = new Route(" << url >> ", new MvcRouteHandler())
    {
        Constraints = new RouteValueDictionary(constraints),
        DataTokens = new RouteValueDictionary(),
        Defaults = new RouteValueDictionary()
    };
    routes.Add(route);
