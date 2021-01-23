    protected void Application_BeginRequest(object sender, EventArgs e)
    {
    	String domainname = HttpContext.Current.Request.Headers["Origin"].ToString();
    	if (IsAllowedDomain(domainname))
    		HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", domainname);
    	String allowedmethods =  "POST, PUT, DELETE, GET";
    	String headers = HttpContext.Current.Request.Headers["Access-Control-Request-Headers"].ToString();
    	String accesscontrolmaxage =  "1728000";
    	String contenttypeforoptionsrequest = "application/json";
    	
    
    	if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
    	{
    		//These headers are handling the "pre-flight" OPTIONS call sent by the browser
    		HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", allowedmethods);
    		HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", headers);
    		HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", accesscontrolmaxage);
    		HttpContext.Current.Response.AddHeader("ContentType", contenttypeforoptionsrequest);
    		HttpContext.Current.Response.End();
    	}
    
    }
    private bool IsAllowedDomain(String Domain)
    {
    	if (string.IsNullOrEmpty(Domain)) return false;
    	string[] alloweddomains = "http://192.168.0.70:8001"; // you can place comma separated domains here.
    	foreach (string alloweddomain in alloweddomains)
    	{
    		if (Domain.ToLower() == alloweddomain.ToLower())
    			return true;
    	}
    	return false;
    }
