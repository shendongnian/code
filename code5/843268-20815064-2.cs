	protected void Application_BeginRequest(Object sender, EventArgs e)		
	{
        // place the lower case on string, to avoid make it again later.
		string cTheLowerUrl = HttpContext.Current.Request.Path.ToLowerInvariant();
		if (cTheLowerUrl != HttpContext.Current.Request.Path)
		{
			HttpContext.Current.Response.Redirect(cTheLowerUrl + HttpContext.Current.Request.Url.Query);
		}
	}
