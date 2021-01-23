    public override Task<HttpResponseMessage> ExecuteAsync(
    	HttpControllerContext controllerContext,
    	CancellationToken cancellationToken
    )
    {
        // Do logging here using controllerContext.Request
        return base.ExecuteAsync(controllerContext, cancellationToken);
    }
