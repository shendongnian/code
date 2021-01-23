    var repositoryTypes = OpenGenericBatchRegistrationExtensions.GetTypesToRegister(
        container, typeof(IRepository<>), repositoryAssembly);
    foreach (Type implementationType in repositoryTypes)
    {
        Type serviceType = 
            implementationType.GetInterfaces().Where(i => !i.IsGenericType).Single();
        container.Register(serviceType, implementationType, Lifestyle.Transient);
    }
