    // assumes there are not multiple file appenders defined
    var appender = log4net.LogManager.GetRepository()
                                     .GetAppenders()
                                     .OfType<FileAppender>()
                                     .SingleOrDefault();
    if (appender != null)
    {
         appender.LockingModel = new FileAppender.MinimalLock();
    }
