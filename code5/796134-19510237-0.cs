    class MyServiceHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new MyServiceHost(serviceType, baseAddresses);
        }
    }
    
    class MyServiceHost : ServiceHost
    {
        public MyServiceHost()
        {
            // initialize, add endpoints, behaviors, etc.
        }
    }
