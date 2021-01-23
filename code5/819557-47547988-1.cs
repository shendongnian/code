    [HttpGet]
    [Route("results/{runId}")]
    public async Task<IHttpActionResult> GetRunResults(int runId)
    {				
    	//Is the current cache key in our cache?
    	//Yes - return 304
    	//No - get data - and update CacheKeys
    	string tag = GetETag(Request);
    	string cacheTag = GetCacheTag("GetRunResults");  //you need to implement this map - or use Redis if multiple web servers
    
        if (tag == cacheTag )
    			return new StatusCodeResult(HttpStatusCode.NotModified, Request);
    
        //Build data, and update Cache...
        string newTag = "123";    //however you define this - I have a DB auto-inc ID on my messages
    
        //Call our new CacheableJsonResult - and assign the new cache tag
    	return new CacheableJsonResult<WebsiteRunResults>(results, GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings, System.Text.UTF8Encoding.Default, Request, newTag);
    
        }
    }
    private static string GetETag(HttpRequestMessage request)
    {
    	IEnumerable<string> values = null;
    	if (request.Headers.TryGetValues("If-None-Match", out values))
    		return new EntityTagHeaderValue(values.FirstOrDefault()).Tag;
    
    	return null;
    }
