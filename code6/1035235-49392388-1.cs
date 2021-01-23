    public class FriendlyUrlConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var friendlyUrl = values[parameterName];
    
            // Your logic to return true/false here
        }
    }
