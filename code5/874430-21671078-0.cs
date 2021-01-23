    public interface IProxy
    {
        void DoSth();
    }
    public class ProxyA : IProxy
    {
        public ProxyA(DataA dataA)
        {
            
        }
        public void DoSth()
        { }
    }
    public class ProxyB : IProxy
    {
        public ProxyB(DataB dataA)
        {
            
        }
        public void DoSth()
        {
            
        }
    }
    public class ViewModel<T> where T : IProxy
    {
        private readonly IProxy _proxy;
        public ViewModel(T proxy)
        {
            _proxy = proxy;
        }
        public void DoSth()
        {
            _proxy.DoSth();
        }
    }
    var vm = new ViewModel<ProxyA>(new ProxyA(new DataA()));
    vm.DoSth();
