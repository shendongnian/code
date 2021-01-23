    public class ActionExistsConstraint : IRouteConstraint
    {
        private readonly Type _controllerType;
        public ActionExistsConstraint(Type controllerType)
        {
            this._controllerType = controllerType;
        }
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var actionName = values["action"] as string;
            if (actionName == null || _controllerType == null || _controllerType.GetMethod(actionName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.IgnoreCase) == null)
                return false;
            return true;
        }
    }
    routes.MapRoute(
        name: "HomeRoute",
        url: "{action}",
        defaults: new { controller = "Home", action = "Index" },
        constraints: new { exists = new ActionExistsConstraint(typeof(HomeController)) }
    );
