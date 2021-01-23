    public class MyControllerBase : Controller
    {
        public RedirectToRouteResult RedirectToAction<TController>(Expression<Func<TController, object>> actionExpression)
        {
	        var custId = ControllerContext.Controller.ViewBag["customId"];
	        string controllerName = typeof(TController).GetControllerName();
            string actionName = actionExpression.GetActionName();
            return RedirectToAction(actionName, controllerName, new {cId = custId});
        }
    }
