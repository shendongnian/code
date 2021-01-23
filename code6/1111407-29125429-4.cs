    public class MyComponent
    {
         public MyComponent(ILog logger)
         {
              this._logger = logger; 
         }
         private readonly ILog _logger; 
         public void Do()
         { 
              this._logger.Info("Log4net OK");
         }
    }
    // ...
    log4net.Config.XmlConfigurator.Configure();
    // ...
    iocBuilder.RegisterModule(new LoggingModule());
    iocBuilder.RegisterType<MyComponent>().AsSelf(); 
    // ...
    MyComponent c = iocContainer.Resolve<MyComponent>();
    c.Do(); 
