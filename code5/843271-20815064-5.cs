	string sExtOfFile = System.IO.Path.GetExtension(HttpContext.Current.Request.Path);
	if (sExtOfFile.Equals(".aspx", StringComparison.InvariantCultureIgnoreCase))
	{
		string cTheLowerUrl = HttpContext.Current.Request.Path.ToLowerInvariant();
		if (cTheLowerUrl != HttpContext.Current.Request.Path)
		{
			HttpContext.Current.Response.Redirect(cTheLowerUrl + HttpContext.Current.Request.Url.Query);
		}
	}
