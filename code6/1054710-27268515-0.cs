     public class CategoryConstraint : IRouteConstraint
     {
          public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
          {
               // code to validate subcategory
          }
     }
