    public class UserTypeARouteConstraint : IRouteConstraint
    {
         bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
         {
             return IsUserOfTypeA(httpContext);
         }
         private bool IsUserOfTypeA(HttpContextbase httpContext)
         {
             // custom logic to figure out the user group
         }
    }
