    IEnumerable<Assembly> referencedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
    if (HostingEnvironment.InClientBuildManager)
    {
        referencedAssemblies = referencedAssemblies
                                     .Union(BuildManager
                                                .GetReferencedAssemblies()
                                                .Cast<Assembly>())
                                     .Distinct();
    }
    
    var groupedAssemblies = referencedAssemblies.Select(ass => new
    {
        Assembly = ass,
        TenantAttribute = ass.GetCustomAttribute<TenantAttribute>()
    })
    .Where(o => o.TenantAttribute != null)
    .GroupBy(o => o.TenantAttribute.TenantId, o => o.Assembly);
    foreach (var group in groupedAssemblies)
    {
        mtc.ConfigureTenant(group.Key, cb =>
        {
            cb.RegisterAssemblyModule(group);
        });
    }
