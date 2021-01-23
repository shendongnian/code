    ContainerBuilder builder = new ContainerBuilder();
    builder.RegisterType<CachedLocationRepository>()
           .As<ILocationRepository>()
           .Keyed<ILocationRepository>(RepositoryType.Cached);
    builder.RegisterType<LocationRepository>()
           .As<ILocationRepository>()
           .Keyed<ILocationRepository>(RepositoryType.Real);
