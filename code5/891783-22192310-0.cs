    public override void ExecuteResult(ControllerContext context)
    {
        ...
        string destinationUrl = UrlHelper.GenerateUrl(
            RouteName, null /* actionName */, null /* controllerName */, 
            RouteValues, Routes, context.RequestContext, 
            false /* includeImplicitMvcValues */);
        
        ...
        context.HttpContext.Response.Redirect(destinationUrl, endResponse: false);
    }
