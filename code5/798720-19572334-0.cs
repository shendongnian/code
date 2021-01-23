    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    class MyService : IMyService 
    {
        private IHelper _helper;
        public MyService() : this(new Helper())
        {
    
        }
    
        public MyService(IHelper helper)
        {
           _helper = helper;
        }
        void DoSomethingCool()
        {
            // How do I pass an instance of helper to MyService so I can use it here???
            helper.HelperMethod();
        }
    }
