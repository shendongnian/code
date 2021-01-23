    public static class UrlHelpers
    {
    	public static string GetUrlHostname(this UrlHelper url)
    	{
    	    var hostname = url.RequestContext.HttpContext.Request.Headers["X-Original-Host"] ?? url.RequestContext.HttpContext.Request.Url.Host;
    	    return hostname;
    	}
    }
