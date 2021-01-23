    public class MySingleton
    {
     private static MySingleton _instance;
     private MySingleton() {} // private constructor
     public static MySingleton Instance
    {
      get 
      {
         if (_instance == null)
         
            _instance = new Singleton();
         
         return _instance;
      }
     }
    }
