    public static MyStaticClassFactory
    {
       public static IMyNonStaticClassBase GetNonStaticClass()
       {
          return new MyNonStaticClass1();    
       }
      
    }
