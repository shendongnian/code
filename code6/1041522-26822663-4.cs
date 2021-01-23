    ITenantContext tenantContext = new AspNetQueryStringTenantContext();
    container.RegisterSingle<ITenantContext>(tenantContext);
    container.Register<Tenant1Dependency>(Lifestyle.Transient);
    container.Register<Tenant2Dependency>(Lifestyle.Singleton);
    container.Register<IDependency, TenantDependencyProxy>(Lifestyle.Singleton);
