    protected void Application_BeginRequest()
    {
        // Here we check if the request was for bundle or not and depending on that
        // apply the cache block depending on that.
    	if (!Request.Url.PathAndQuery.StartsWith("/bundles/"))
    	{
    		Response.Cache.SetAllowResponseInBrowserHistory(false);
    		Response.Cache.SetCacheability(HttpCacheability.NoCache);
    		Response.Cache.SetNoStore();
    		Response.Cache.SetExpires(DateTime.Now);
    		Response.Cache.SetValidUntilExpires(true);
    	}
    }
