    var routes = System.Web.Http.GlobalConfiguration.Configuration.Routes;
    var field = routes.GetType().GetField("_routeCollection", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
    var collection = field.GetValue(routes) as System.Web.Routing.RouteCollection;
    var routeList = collection
        .OfType<IEnumerable<System.Web.Routing.RouteBase>>()
        .SelectMany(c => c)
        .Cast<System.Web.Routing.Route>()
        .Concat(collection.OfType<System.Web.Routing.Route>())
        .Select(r => $"{r.Url} ({ r.GetType().Name})")
        .OrderBy(r => r)
        .ToArray();
