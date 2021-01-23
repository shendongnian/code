    public void OnActionExecuting(ActionExecutingContext context)
    {
        var routeData = context.RouteData;
        var httpContext = context.HttpContext;
        ...
    }
