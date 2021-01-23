    [OperationContract]
    public SomeData DoSomething() {
        using (Bootstrapper.Container.BeginLifetimeScope()) {
            return Bootstrapper.Container.GetInstance<IDoSomethingService>()
                .DoSomething();
        }
    }
 
