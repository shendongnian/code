    public sealed class Singleton
    {
       private static readonly Singleton instance;
       
       private Singleton() { }
    
       static Singleton()
       {
          instance = new Singleton()
       }
    
       public static Singleton Instance
       {
          get 
          {
             return instance; 
          }
       }
    }
