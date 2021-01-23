    public override void Init()
	{
        base.Init();
        var loggingConfiguration = ConfigurationManager.GetSection("LoggingConfiguration") as LoggingConfiguration;
	    if (loggingConfiguration != null)
	    {	            
	        new JsonLogger(loggingConfiguration.ConnectionString).Init(this); 
	    }
	}
