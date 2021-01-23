    public sealed class FooList 
    {
       private static volatile FooList instance;
       private static object syncRoot = new Object();
    
       private FooList ()
       {
            Data = .... // fill in how to fetch the data here, gets executed only once
       }
    
       public static FooList Instance
       {
          get 
          {
             if (instance == null) 
             {
                lock (syncRoot) 
                {
                   if (instance == null) 
                      instance = new FooList ();
                }
             }
    
             return instance;
          }
       }
    
       public IList<Foo> Data { get; private set; }
    }
