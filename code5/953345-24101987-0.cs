    public override void OnException(ExceptionContext filterContext)
    {
        if(filterContext.Exception is TimeoutException && filterContext.Controller is AsyncController)
        {
            filterContext.HttpContext.Response.StatusCode = 200;
            filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                        { "Controller", "Home" },
                        { "Action", "TimeoutRedirect" }
            filterContext.ExceptionHandled = true;
        }
        base.OnException(filterContext);
    }
