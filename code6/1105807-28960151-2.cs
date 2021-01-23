    public class CheckUserIdRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (!WebSecurity.Initialized)
                return false;
            var userId = WebSecurity.CurrentUserId;
            // check your user id
            return userId == 1;
        }
    }
