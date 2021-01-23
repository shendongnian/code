    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        if (TooManyRequests()) {
            throw new HttpResponseException((HttpStatusCode)429);
        }
        base.OnActionExecuting(filterContext);
    }
