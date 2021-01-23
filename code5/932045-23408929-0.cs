    public class CustomLogger
    {
        private readonly ILog log;
        public CustomLogger(string name)
        {
            var repository = LogManager.CreateRepository(name);
            Hierarchy hierarchy = (Hierarchy)repository;
            hierarchy.Root.RemoveAllAppenders(); //Remove any other appenders
            RollingFileAppender fileAppender = new RollingFileAppender();
            fileAppender.MaxFileSize = 10000000; //10MB in bytes
            fileAppender.MaxSizeRollBackups = 10;
            fileAppender.RollingStyle = RollingFileAppender.RollingMode.Size;
            fileAppender.AppendToFile = true;
            fileAppender.LockingModel = new FileAppender.MinimalLock();
            fileAppender.File = @"C:\" + name + "_LOG.txt";
            PatternLayout pl = new PatternLayout();
            pl.ConversionPattern = "%utcdate,%message%newline";
            pl.ActivateOptions();
            fileAppender.Layout = pl;
            fileAppender.ActivateOptions();
            log4net.Config.BasicConfigurator.Configure(repository, fileAppender);
            this.log = LogManager.GetLogger(name, name);
        }
        public void Log(string message)
        {
            this.log.Info(message);
        }
    }
