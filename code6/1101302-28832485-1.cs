    [TestInitialize]
    public void Setup()
    {
        log4net.GlobalContext.Properties["LogName"] = "testlogger";
    
        var fileInfo = new FileInfo("log4net.config.xml");
    
        if (fileInfo.Exists == false)
        {
    	    throw new InvalidOperationException("Can't locate the log4net config file");
        }
    
        LogManager.ResetConfiguration();
        log4net.Config.XmlConfigurator.Configure(fileInfo);
    }
    
    [TestMethod]
    [DeploymentItem(@"log4net.config.xml")]
    public void log4net_RollingFileAppender_Is_Configured_Correctly()
    {
       var appender = log4net.LogManager.GetRepository()
                                        .GetAppenders()
                                        .OfType<RollingFileAppender>()
                                        .First();
    
        Console.WriteLine(appender.File);
        Console.WriteLine(Path.GetDirectoryName(appender.File));
    }
