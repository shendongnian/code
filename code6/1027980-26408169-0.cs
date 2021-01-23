    var container = new UnityContainer();
    
    // this will cause the Model to only be created once and shared to other types that have been registered in the container
    //
    container.RegisterType<ISharedModel, SharedModel>(new ContainerControlledLifetimeManager()); 
    container.RegisterType<IViewModel1, ViewModel1>();
    container.RegisterType<IViewModel2, ViewModel2>();
