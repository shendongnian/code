    var container = new ContainerConfiguration()
        .WithExport<IAmMocked>(mockObject)
        .WithAssemblies(
            new[] { Assembly.GetAssembly(typeof(ICache)) }, conventions)
        .CreateContainer();
