    Container container = new Container();
    container.Options.DefaultScopedLifestyle = new     SimpleInjector.Lifestyles.ThreadScopedLifestyle();
    container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
    
    using (SimpleInjector.Lifestyles.ThreadScopedLifestyle.BeginScope(container))
    {
    	var _uow = container.GetInstance<IUnitOfWork>();
    	// put your business code here ...
    }
