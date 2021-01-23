    Mapper.Initialize(cfg =>
    {
        // map properties with public or internal getters
        cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
        cfg.CreateMap<Source, Destination>();
    });
