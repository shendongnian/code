    public static class ControllerExtensions
    {
        public static ActionResult RedirectToAction<TController>(
            this Controller controller, 
            Expression<Func<TController, ActionResult>> expression)
            where TController : Controller
        {
            var fullControllerName = typeof(TController).Name;
            var controllerName = fullControllerName.EndsWith("Controller")
                ? fullControllerName.Substring(0, fullControllerName.Length - 10)
                : fullControllerName;
            var actionCall = (MethodCallExpression) expression.Body;
            return controller.RedirectToAction(actionCall.Method.Name, controllerName);
        }
    }
