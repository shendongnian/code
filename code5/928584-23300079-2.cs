    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        usingVaribale = WindowsIdentity.GetCurrent().Impersonate();
        filterContext.ActionParameters.Add("parameterName", usingVaribale);
    }
