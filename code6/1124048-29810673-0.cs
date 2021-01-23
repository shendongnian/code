    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        filterContext.HttpContext.Response.StatusCode = 429; // Too many requests
        filterContext.Result = new ContentResult
        {
            Content = "Too Many Requests"
        };
        base.OnActionExecuting(filterContext);
    }
