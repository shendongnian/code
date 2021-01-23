    public override object OnAfterExecute(IRequestContext requestContext, object response)
    {
        var resp = requestContext.Get<IHttpResponse>();
        response = requestContext.ToOptimizedResult(requestContext.Get<IHttpResponse>().OutputStream);       
        return base.OnAfterExecute(requestContext, response);
    }
