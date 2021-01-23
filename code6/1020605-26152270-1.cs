    public class MyServiceBase : Service
    {
        public ISharedDep SharedDep { get; set] 
    
        public object SharedMethod(object request)
        {
            //...
        }
    }
    public class MyServices1 : MyServiceBase { ... }
    public class MyServices2 : MyServiceBase { ... }
