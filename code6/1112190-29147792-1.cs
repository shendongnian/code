    IEnumerable<Assembly> referencedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
    if (HostingEnvironment.InClientBuildManager)
    {
        referencedAssemblies = referencedAssemblies
                                     .Union(BuildManager
                                                .GetReferencedAssemblies()
                                                .Cast<Assembly>())
                                     .Distinct();
    }
    
    foreach(Assembly assembly in referencedAssemblies)
    {
        TenantAttribute tenantAttribute = ass.GetCustomAttribute<TenantAttribute>();
        if(tenantAttribute != null)
        {
            String tenantId = tenantAttribute.AttributeId;
            mtc.ConfigureTenant(tenantId, cb => 
            {
                cb.RegisterAssemblyModule(assembly);
            });        
        }
    }
