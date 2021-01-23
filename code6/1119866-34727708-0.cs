    private static SessionStateBehavior SessionStateBehavior(IDictionary<string, object> dataTokens)
    {
      return dataTokens.ContainsKey("SessionStateBehavior") ? (SessionStateBehavior)dataTokens["SessionStateBehavior"] : System.Web.SessionState.SessionStateBehavior.Default;
    }
    public static SessionStateBehavior SessionStateBehavior(this IHttpRoute route)
    {
      return SessionStateBehavior(route.DataTokens);
    }
    public static SessionStateBehavior SessionStateBehavior(this RouteData routeData)
    {
      return SessionStateBehavior(routeData.DataTokens);
    }
    public static void SessionStateBehavior(this IHttpRoute route, SessionStateBehavior behavior)
    {
      route.DataTokens["SessionStateBehavior"] = behavior;
    }
