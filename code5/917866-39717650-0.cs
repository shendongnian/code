    `var aiInstrumentationKey = System.Web.Configuration.WebConfigurationManager.AppSettings["appInsightsInstrumentationKey"];
	if( string.IsNullOrEmpty(aiInstrumentationKey))
	{
		throw new ApplicationException("appInsightsInstrumentationKey missing in web.config");
	}
	Microsoft.ApplicationInsights.Extensibility.TelemetryConfiguration.Active.InstrumentationKey = aiInstrumentationKey;`
	
      
