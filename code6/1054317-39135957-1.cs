    public class UserNameConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            List<string> users = new List<string>() { "username1", "username2" };
            
            var username = values["username"].ToString().ToLower();
            
            return users.Any(x => x.ToLower() == username);
        }
    }
