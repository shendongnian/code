    var assembly = Assembly.LoadFile(dllPath);
    var dataRepositoryType = typeof(IDataRepository);
    var types = assembly.GetTypes()
        .Where(dataRepositoryType.IsAssignableFrom).ToList();
    // thow error if more than one implementing type
    IKernel kernel = new StandardKernel();
    kernel.Bind<IDataRepository>().To(types[0]);
    var repo = kernel.Get<IDataRepository>();
