    public sealed class Configuration
    {
       private static volatile Configuration instance;
       private static object syncRoot = new Object();
    
       private Configuration() {}
    
       public static Configuration Instance
       {
          get 
          {
             if (instance == null) 
             {
                lock (syncRoot) 
                {
                   if (instance == null) 
                      instance = new Configuration();
                }
             }
    
             return instance;
          }
       }
    }
 
