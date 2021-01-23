	public override string GetVaryByCustomString(HttpContext context, string custom)
	{
		// let the base method handle everything else
		if (!custom.Equals("locale", StringComparison.CurrentCultureIgnoreCase))
			return base.GetVaryByCustomString(context, custom);
		// if the query param is "locale", return a string that varies with the value.
		// in our case, since we're setting `CurrentUICulture`, we can use its `Name`.
		return Thread.CurrentThread.CurrentUICulture.Name;
	}
