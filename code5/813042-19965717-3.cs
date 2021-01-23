	log4net.Config.XmlConfigurator.Configure();
	log4net.Repository.Hierarchy.Hierarchy hier = log4net.LogManager.GetRepository() as log4net.Repository.Hierarchy.Hierarchy;
	if (hier != null)
	{
	    var adoAppender = (AdoNetAppender)hier.GetAppenders()
							.Where(appender => appender.Name.Equals("AdoNetAppender", StringComparison.InvariantCultureIgnoreCase))
							.FirstOrDefault();
		if (adoAppender != null)
		{
			adoAppender.ConnectionString = connstring;
			adoAppender.ActivateOptions(); //refresh settings of appender
		}
	}
	ILog log = LogManager.GetLogger("test");
	log.Info("Test Message");
