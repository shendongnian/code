    protected override void Initialize(System.Web.Routing.RequestContext requestContext)
    {
        if (requestContext.HttpContext.Session["MemberId"] == null)
        {
            //....Redirect to login page
        }
        base.Initialize(requestContext);
    }
