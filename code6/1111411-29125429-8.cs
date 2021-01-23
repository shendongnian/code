    log4net.Config.XmlConfigurator.Configure();
    /// ...
    ContainerBuilder cb = new ContainerBuilder()
    cb.Register(c => LogManager.GetLogger(typeof(Object))).As<ILog>();
    IContainer container = cb.Build(); 
