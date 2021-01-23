    ITenantContext tenantContext = new AspNetQueryStringTenantContext();
    container.RegisterSingle<ITenantContext>(tenantContext);
    container.Register<Tenant1Dependency>(Lifestyle.Transient);
    container.Register<Tenant2Dependency>(Lifestyle.Singleton);
    container.Register<IDependency>(() => {
        switch (tenantContext.TenantId) {
            case "abc": return this.container.GetInstance<Tenant1Dependency>();
            default: return this.container.GetInstance<Tenant2Dependency>();
        }
    });
