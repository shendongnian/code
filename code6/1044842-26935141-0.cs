    var assembly = typeof(YourRepository).Assembly;
    
    var registrations =
        from type in assembly.GetExportedTypes()
        where type.Namespace == "Acme.YourRepositories"
        where type.GetInterfaces().Any()
        select new
        {
            Service = type.GetInterfaces().Single(),
            Implementation = type
        };
    
    foreach (var reg in registrations)
        container.Register(reg.Service, reg.Implementation, new WebApiRequestLifestyle());
