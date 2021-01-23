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
            helper.HelperMethod();
        }
    }
