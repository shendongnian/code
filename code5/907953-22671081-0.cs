    public class AppFeatureUrlConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values[parameterName] != null)
            {
                var url = values[parameterName].ToString();
                return url.Length == 13 && url.EndsWith("myApp/Feature", StringComparison.InvariantCultureIgnoreCase) ||
                        url.Length > 13 && url.EndsWith("/myApp/Feature", StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }
    }
