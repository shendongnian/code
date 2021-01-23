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
