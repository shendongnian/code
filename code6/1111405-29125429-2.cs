    public class MyComponent
    {
         public MyComponent(ILog logger)
         {
              this._logger = logger; 
              log4net.Config.XmlConfigurator.Configure();
         }
         private readonly ILog _logger; 
         public void Do()
         { 
              this._logger.Info("Log4net OK");
         }
    }
    // ...
    iocBuilder.RegisterType<MyComponent>().AsSelf(); 
    // ...
    MyComponent c = iocContainer.Resolve<MyComponent>();
    c.Do(); 
