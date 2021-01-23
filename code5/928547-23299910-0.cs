    protected override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        var request = filterContext.HttpContext.Request;
        // If the request is AJAX, let it go through
        if (request.Headers["X-Requested-With"].IsEqualTo("xmlhttprequest"))
        {
            base.OnActionExecuting(filterContext);
        }
        // If the request is not AJAX, then the response needs to be modified.
        else
        {
            // Get original values of controller and action data
            var controllerName = filterContext.RouteData.Values["Controller"].ToString();
            var actionName = filterContext.RouteData.Values["Action"].ToString();
            // Set new values so that the view engine knows what view to render
            filterContext.RouteData.Values["Controller"] = "Application";
            filterContext.RouteData.Values["Action"] = "Container";
            // This is the controller that contains the single-page application view.
            var applicationController = new ApplicationController();
            applicationController.ControllerContext = 
                new ControllerContext(ControllerContext.RequestContext, applicationController);
            // Render the single page application and let it take care of the result
            filterContext.Result = applicationController.Container(controllerName, actionName, null);
        }
    }
