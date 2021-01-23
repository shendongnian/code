       // Let it be thread-safe
       private static ThreadLocal<Random> s_Gen = new ThreadLocal<Random>(
        () => new Random());
    
       // Thread-safe non-skewed generator
       public static Random Generator {
         get {
           return s_Gen.Value;
         }
       }
     
       ...
    
       int toss = Generator.Next(1,3);
