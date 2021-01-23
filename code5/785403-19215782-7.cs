    public static class Extensions
    {
    	public static async Task<HttpWebResponse> GetResponseAsync(this HttpWebRequest request, CancellationToken ct)
    	{
    		using (ct.Register(() => request.Abort(), useSynchronizationContext: false))
    		{
    			try
    			{
    				var response = await request.GetResponseAsync();
    				ct.ThrowIfCancellationRequested();
    				return (HttpWebResponse)response;
    			}
    			catch (WebException ex)
    			{
    				// WebException is thrown when request.Abort() is called,
    				// but there may be many other reasons,
    				// propagate the WebException to the caller correctly
    
    				if (!ct.IsCancellationRequested)
    				{
    					// not cancelled by ct, rethrow the WebException
    					throw;
    				}
    
    				if (ex.Status == WebExceptionStatus.RequestCanceled)
    				{
    					// caused by request.Abort(),
    					// throw a generic task cancellation exception
    					ct.ThrowIfCancellationRequested();
    				}
    
    				// any other reason, but cancellation request has the priority,
    				// the WebException will be available as Exception.InnerException
    				throw new TaskCanceledException(ex.Message, ex);
    			}
    		}
    	}
    }
