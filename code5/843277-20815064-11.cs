    string sExtOfFile = System.IO.Path.GetExtension(HttpContext.Current.Request.Path);
    if (sExtOfFile.Equals(".aspx", StringComparison.InvariantCultureIgnoreCase))
    {
    	string cTheLowerUrl = HttpContext.Current.Request.Path.ToLowerInvariant();
    	if (cTheLowerUrl != HttpContext.Current.Request.Path)
    	{
                // for asp.net 4 and above
                HttpContext.Current.Response.RedirectPermanent(cTheLowerUrl + HttpContext.Current.Request.Url.Query);
                // or using the above function.
    		    // RedirectPermanent(cTheLowerUrl + HttpContext.Current.Request.Url.Query);
    	}
    }
