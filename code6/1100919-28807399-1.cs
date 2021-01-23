    public static IHttpRoute MapHttpRoute(this HttpRouteCollection routes, string name, string routeTemplate, object defaults, object constraints, HttpMessageHandler handler)
    {
      if (routes == null)
        throw Error.ArgumentNull("routes");
      HttpRouteValueDictionary routeValueDictionary1 = new HttpRouteValueDictionary(defaults);
      HttpRouteValueDictionary routeValueDictionary2 = new HttpRouteValueDictionary(constraints);
      IHttpRoute route = routes.CreateRoute(routeTemplate, (IDictionary<string, object>) routeValueDictionary1, (IDictionary<string, object>) routeValueDictionary2, (IDictionary<string, object>) null, handler);
      routes.Add(name, route);
      return route;
    }
