        public static ActionResult RedirectToAction<TController>(this Controller controller, Expression<Func<TController, ActionResult>> expression)
            where TController : Controller
        {
            var fullControllerName = typeof(TController).Name;
            var controllerName = fullControllerName.EndsWith("Controller")
                ? fullControllerName.Substring(0, fullControllerName.Length - 10)
                : fullControllerName;
            var actionCall = (MethodCallExpression)expression.Body;
            var routeValues = new ExpandoObject();
            var routeValuesDictionary = (IDictionary<String, Object>)routeValues;
            var parameters = actionCall.Method.GetParameters();
            for (var i = 0; i < parameters.Length; i++)
            {
                var arugmentLambda = Expression.Lambda(actionCall.Arguments[i], expression.Parameters);
                var arugmentDelegate = arugmentLambda.Compile();
                var argumentValue = arugmentDelegate.DynamicInvoke(controller);
                routeValuesDictionary[parameters[i].Name] = argumentValue;
            }
            return controller.RedirectToAction(actionCall.Method.Name, controllerName, routeValues);
        }
