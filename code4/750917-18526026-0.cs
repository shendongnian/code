    public class Service1:IService1
    {
        private ILog _log;
        public Service1(ILog<Service1> log)
        {
            _log = log;
        }
    
        public void DoSomething()
        {
            _log.Print();
        }
    }
    
    public class Service2:IService2
    {
        private ILog _log;
        public Service2(ILog<Service2> log)
        {
            _log = log;
        }
    
        public void DoSomething()
        {
            _log.Print();
        }
    }
    
    public interface ILog
    {
        void Print();
    }
    public interface ILog<T> : ILog 
    {
        //Any type specific methods
    }
    public class Log<T> : ILog<T>
    {
        public void Print()
        {
            Console.Writeline("Owner:  {0}", typeof(T).Name);
        }
    }
    unityContainer.RegisterType<IService1, Service1>();
    unityContainer.RegisterType<IService2, Service2>();
    unityContainer.RegisterType(typeof(ILog<>), typeof(Log<>))
    
    var s1 = unityContainer.Resolve<IService1>();
    var s2 = unityContainer.Resolve<IService2>();
    
    s1.DoSomething(); // Should print "Owner:  Service1"
    s2.DoSomething(); // Should print "Owner:  Service2"
