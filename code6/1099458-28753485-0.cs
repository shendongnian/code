    var registrations =
        from type in typeof(UserService).Assembly.GetExportedTypes()
        where type.Namespace.StartsWith("Services.Interfaces")
        where type.GetInterfaces().Any()
        select new { Service = type.GetInterfaces().Single(), Implementation = type };
    foreach (var reg in registrations) {
        container.Register(reg.Service, reg.Implementation);
    }
