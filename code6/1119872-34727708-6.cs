    public static class SessionHelper
    {
      private static SessionStateBehavior GetSessionStateBehavior(IDictionary<string, object> dataTokens)
      {
        return dataTokens.ContainsKey("SessionStateBehavior") ? (SessionStateBehavior)dataTokens["SessionStateBehavior"] : SessionStateBehavior.Default;
      }
      public static SessionStateBehavior GetSessionStateBehavior(this IHttpRoute route)
      {
        return GetSessionStateBehavior(route.DataTokens);
      }
      public static SessionStateBehavior GetSessionStateBehavior(this RouteData routeData)
      {
        return GetSessionStateBehavior(routeData.DataTokens);
      }
      public static void SetSessionStateBehavior(this IHttpRoute route, SessionStateBehavior behavior)
      {
        route.DataTokens["SessionStateBehavior"] = behavior;
      }
      public static IHttpRoute MapHttpRoute(this HttpRouteCollection routes, string name, string routeTemplate, object defaults, SessionStateBehavior behavior)
      {
        return MapHttpRoute(routes, name, routeTemplate, defaults, null, behavior);
      }
      public static IHttpRoute MapHttpRoute(this HttpRouteCollection routes, string name, string routeTemplate, object defaults, object constraints, SessionStateBehavior behavior)
      {
        var route = routes.CreateRoute(routeTemplate, defaults, constraints);
        SetSessionStateBehavior(route, behavior);
        routes.Add(name, route);
      
        return route;
      }
    }
