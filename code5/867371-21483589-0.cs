    public override void OnActionExecuted(ActionExecutedContext filterContext)
    {
    	base.OnActionExecuted(filterContext);
    	CachedPages.Add(filterContext.HttpContext.Request.CurrentExecutionFilePath);
    }
