    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
    	CorsRequestContext corsRequestContext = request.GetCorsRequestContext();
    	HttpResponseMessage result;
    	if (corsRequestContext != null)
    	{
        try
        {
        	if (corsRequestContext.IsPreflight)
        	{
            result = await this.HandleCorsPreflightRequestAsync(request, corsRequestContext, cancellationToken);
            return result;
        	}
        	result = await this.HandleCorsRequestAsync(request, corsRequestContext, cancellationToken);
        	return result;
        }
        catch (Exception exception)
        {
        	result = CorsMessageHandler.HandleException(request, exception);
        	return result;
        }
    	}
    	result = await this.<>n__FabricatedMethod3(request, cancellationToken);
    	return result;
    }
