    public class RemoveDashRoute : Route
    {
        private const string ControllerKey = "controller";
        public RemoveDashRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints = null, RouteValueDictionary dataTokens = null, IRouteHandler routeHandler = null)
            : base(url, defaults, constraints ?? new RouteValueDictionary(), dataTokens ?? new RouteValueDictionary(), routeHandler ?? new MvcRouteHandler())
        {
        }
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var routeData = base.GetRouteData(httpContext);
            if (routeData != null && routeData.Values.ContainsKey(ControllerKey))
            {
                routeData.Values[ControllerKey] = ((string)routeData.Values[ControllerKey]).Replace("-", String.Empty);
            }
            return routeData;
        }
    }
