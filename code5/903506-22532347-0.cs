    public override void OnAuthorization(HttpActionContext actionContext)
    {
        base.OnAuthorization(actionContext);
        var canX = // Get value here
        //Custom validation here...
        HandleUnauthorizedRequest(actionContext);
    }
