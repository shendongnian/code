    public class MyService1 : Service
    {
        public ISharedDep SharedDep { get; set] 
    
        public object Any(Request1 request)
        {
            //...
        }
    }
    
    public class MyService2 : Service
    {
        public ISharedDep SharedDep { get; set] 
    
        public object Any(Request2 request)
        {
            //...
        }
    }
