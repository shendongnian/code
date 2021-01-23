    public class JsonMessageLoggerHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
    		bool isJson = false;
    	    //not tested, you may have to play with this
            if (request.Content != null && request.Content.Headers.ContentType.MediaType == "application/json")
    		{
    			isJson = true;
    			var requestText = await request.Content.ReadAsStringAsync();
    			LogMethod(requestText);
    		}
            // Call the inner handler.
            var response = await base.SendAsync(request, cancellationToken);
            
    		//log the response
    		if (isJson)
    		{
    			var responseText = await response.Content.ReadAsStringAsync();
    			LogMethod(responseText);
    		}
    		
            return response;
        }
    }
