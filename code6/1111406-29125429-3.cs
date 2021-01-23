    ContainerBuilder cb = new ContainerBuilder
    cb.Register(c => LogManager.GetLogger(typeof(Object))).As<ILog>();
    IContainer container = cb.Build(); 
    ILog logger = container.Resolve<ILog>();
    logger.Info("log4net OK"); 
