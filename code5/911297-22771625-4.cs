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
