    public class DelegateConstraint : IRouteConstraint
    {
        private readonly Func<HttpContextBase, bool> _isMatch;
        public DelegateConstraint(Func<HttpContextBase, bool> isMatch)
        {
            _isMatch = isMatch;
        }
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return _isMatch(httpContext);
        }
    }
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "CustomAuth1",
                url: "AuthArea/{action}/{id}",
                defaults: new { controller = "Department", action = "Index", id = UrlParameter.Optional },
                constraints: new { auth = new DelegateConstraint(httpContext => !httpContext.Request.IsAuthenticated) }
                );
            routes.MapRoute(
                name: "CustomAuth2",
                url: "AuthArea/{action}/{id}",
                defaults: new { controller = "Account", action = "Index", id = UrlParameter.Optional },
                constraints: new { auth = new DelegateConstraint(httpContext => httpContext.Request.IsAuthenticated) }
                );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
