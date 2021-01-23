     private static object TestStaticFunction()
     {
        return "test";
     }
     public static Func<object> GetStaticFunction
     {
         get { return TestStaticFunction; }
     }
