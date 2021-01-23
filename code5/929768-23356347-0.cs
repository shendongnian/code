    public override bool AllowMultiple
    {
        get { return false; }
    }
    public override void OnAuthorization(HttpActionContext actionContext)
    {
        //Perform your logic here
        base.OnAuthorization(actionContext);
    }
}
