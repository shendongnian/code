    [OperationContract]
    public SomeData DoSomething() {
		using (Bootstrapper.Container.BeginLifetimeScope()) {
		    Bootstrapper.Container.GetInstance<IDoSomethingService>()
		        .DoSomething();
		}
	}
 
