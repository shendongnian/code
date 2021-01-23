        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string action = "MyAction;
            string controller = "MyController";
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action, controller}));
        }
