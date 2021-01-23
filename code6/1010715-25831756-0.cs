    [Export(typeof(IMyInterface))]
    public class ProxyClass : IMyInterface
    {
        private IMyInterface impl;
        public ProxyClass()
        {
            if (IsVs2014())
            {
                impl = new Vs2014Impl();
            }
            else
            {
                impl = new Vs2013Impl();
            }
        }
        public void DoSomething()
        {
            impl.DoSomething();
        }
    }
