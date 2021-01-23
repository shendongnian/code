    protected override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        base.OnActionExecuting(filterContext);
        var req = filterContext.RequestContext.HttpContext.Request;
        if (req.HttpMethod == "GET")
        {
            filterContext.RequestContext.HttpContext.Session["testsession"] = req.Url;
        }
    }
