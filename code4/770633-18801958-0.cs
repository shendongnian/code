    public class AdminRootConstraint : IRouteConstraint
    {
        public bool Match
        (
            HttpContextBase httpContext,
            Route route,
            string parameterName,
            RouteValueDictionary values,
            RouteDirection routeDirection
        )
        {
            if ((string) values["controller"] == "Login")
            {
                return true;
            }
    
            object isAuthorized = httpContext.Session["IsAuthorized"];
            return (isAuthorized != null && (bool)isAuthorized);
        }
    }
