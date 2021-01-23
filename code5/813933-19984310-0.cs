    public sealed class Singleton
    {
       private static readonly Singleton instance;
       private bool initialised = false; 
    
       private Singleton(){}
    
       public static Singleton Instance
       {
          get 
          {
            if(initialised)
              return instance; 
            else {
                   initialsed = true;
                   instance = new Singleton();
                   return instance; 
                 }
          }
       }
    
       public int prop1 {get; set;}
    }
