    container.Register(Classes.FromAssemblyInThisApplication().BasedOn<ISetLifestyle>().WithServiceBase());
    var myCustomLifestyleSetter = container.Resolve<ISetLifestyle>();
    
    var customLifestyleRegistrations = myCustomLifestyleSetter.SetLifestyle(Classes.FromThisAssembly().Pick().WithServiceDefaultInterfaces());
    container.Register(customLifestyleRegistrations);
