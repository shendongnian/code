    class ViewModel<TProxy, TData>
    {
        private TProxy proxy;
        public ViewModel(TProxy proxy)
        {
            this.proxy = proxy;
        }
        public void DoSth()
        {
            proxy.DoSth();
        }
        public TProxy Proxy
        {
            get
            {
                return proxy;
            }
        }
    }
    class ViewModelA : ViewModel<ProxyA, DataA>
    {
        public ViewModelA(DataA data) : base(new ProxyA(data))
        {
        }
    }
