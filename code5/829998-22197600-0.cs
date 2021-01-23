    public class MyRouteConstratint : IRouteConstraint
        {
            public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
            {
                //Logic goes here
                return true;
            }
        }
