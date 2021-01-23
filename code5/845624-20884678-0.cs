    System.Configuration.Configuration rootWebConfig =
    System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/YourWebSiteRoot");
	System.Configuration.ConnectionStringSettings connString;
	if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
	{
		connString = rootWebConfig.ConnectionStrings
    				 .ConnectionStrings["StudentConnectionString"];
	}
