    var repositoryAssembly = typeof(SqlUserRepository).Assembly;
    
    var registrations =
        from type in repositoryAssembly.GetExportedTypes()
        where type.Namespace == "MyComp.MyProd.BL.SqlRepositories"
        where type.GetInterfaces().Any()
        select new { Service = type.GetInterfaces().Single(), Implementation = type };
    
    foreach (var reg in registrations) {
        container.Register(reg.Service, reg.Implementation, Lifestyle.Transient);
    } 
