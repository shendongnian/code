    protected override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        base.OnActionExecuting(filterContext);
        if (Session != null)
            Session["selectedData"] = "Hello World";
    }
