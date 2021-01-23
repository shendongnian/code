    public class RemoveDashRoute : Route
    {
        public RemoveDashRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints = null, RouteValueDictionary dataTokens = null, IRouteHandler routeHandler = null)
            : base(url, defaults, constraints ?? new RouteValueDictionary(), dataTokens ?? new RouteValueDictionary(), routeHandler ?? new MvcRouteHandler())
        {
        }
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var routeData = base.GetRouteData(httpContext);
            if (routeData != null)
            {
                routeData.Values["controller"] = ((string)routeData.Values["controller"]).Replace("-", String.Empty);
            }
            return routeData;
        }
    }
