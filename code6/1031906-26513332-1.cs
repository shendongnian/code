    public sealed class StdSchedulerFactory
    {
       private static readonly StdSchedulerFactory instance;
       private NameValueCollection _properties;
    
       private StdSchedulerFactory(NameValueCollection properties)
       {
           _properties = properties;
       }
    
       public static StdSchedulerFactory GetInstance(NameValueCollection properties)
       {
          if (instance == null)
          {
             instance = new StdSchedulerFactory();
          }
          else
          {
             return instance;
          }
       }
    }
