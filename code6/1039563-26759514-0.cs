	_container = new UnityContainer();		
	//Register location specific factories
	_container.RegisterType<ICarFactory,BMWFactory>("Hamburg");
    ...
	//Register the default factory
	_container.RegisterType<ICarFactory,WolksvagenFactory>();
