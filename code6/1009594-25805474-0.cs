    // Castle.Services.Logging.NLogIntegration.NLogFactory
    public override ILogger Create(string name)
    {
    	Logger logger = LogManager.GetLogger(name);
    	return new NLogLogger(logger, this);
    }
