	System.Configuration.Configuration rootWebConfig1 =
		System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(null);
	if (rootWebConfig1.AppSettings.Settings.Count > 0)
	{
		bool inProd = rootWebConfig1.AppSettings.Settings["InProduction"];
	}
