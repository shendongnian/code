    class AuthenticationHandler : DelegatingHandler
    {
    	protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    	{
    		// Your code here
    		return base.SendAsync(request, cancellationToken);
    	 }
    }
    
    And you need register it 
    
    static class WebApiConfig
    {
    	public static void Register(HttpConfiguration config)
    	{					
    		// Other code for WebAPI registerations here
    		config.MessageHandlers.Add(new AuthenticationHandler());			
    	}
    }
