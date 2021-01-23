    protected override void Initialize(System.Web.Routing.RequestContext requestContext)
    {
        var hostname = requestContext.HttpContext.Request.Url.Host;
    
        // do something based on 'hostname' value
        // ....
    
        base.Initialize(requestContext);
    }
