	protected void Application_BeginRequest(Object sender, EventArgs e)		
	{
		string cTheLowerUrl = HttpContext.Current.Request.Path.ToLowerInvariant();
		if (cTheLowerUrl != HttpContext.Current.Request.Path)
		{
			HttpContext.Current.Response.Redirect(cTheLowerUrl);
		}
	}
