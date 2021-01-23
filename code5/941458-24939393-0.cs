    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        var response = filterContext.HttpContext.Response;
        if (response.Filter == null) return; // <-----
        response.Filter = new YourFilter(response.Filter);
    }
