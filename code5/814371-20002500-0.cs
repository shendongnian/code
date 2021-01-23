    public class LazySingleton3
    {
         // static holder for instance, need to use lambda to enter code here
         //construct since constructor private
         private static readonly Lazy<LazySingleton3> _instance
             = new Lazy<LazySingleton3>(() => new LazySingleton3(), 
                                              LazyThreadSafeMode.PublicationOnly);
      
         // private to prevent direct instantiation.
         private LazySingleton3()
         {
         }
      
         // accessor for instance
         public static LazySingleton3 Instance
         {
             get
             {
                 return _instance.Value;
             }
         }
    }
