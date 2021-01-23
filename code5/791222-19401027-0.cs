    protected override void OnActionExecuted(ActionExecutedContext filterContext)
    {
        if (filterContext.Exception == null)
            return;
        // Avoid 'action parameter missing' exceptions by simply returning an error response
        if (filterContext.Exception.TargetSite.DeclaringType == typeof(ActionDescriptor) &&
            filterContext.Exception.TargetSite.Name == "ExtractParameterFromDictionary")
        {
            filterContext.ExceptionHandled = true;
            filterContext.Result = new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
        }
    }
