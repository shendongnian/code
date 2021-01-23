    public ThreadSafeService : IService
    {
        private readonly IServiceFactory factory;
    
        public ThreadSafeService(IServiceFactory factory)
        {
            this.factory = factory;
        }
    
        public void DoSomething()
        {
            this.factory.Create().DoSomething();
        }
    }
