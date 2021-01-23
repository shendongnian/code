    container.Register(Component.For<IConfiguration>().ImplementedBy<Configuration>());
    container.Register(Component
        .For<Person>()
        .DynamicParameters((DynamicParametersDelegate)ResolvePersonName));
    // This should be a private method in your bootstrapper 
    void ResolvePersonName(IKernel kernel, IDictionary parameters)
	{
		parameters["name"] = kernel.Resolve<IConfiguration>().Name;
    }
