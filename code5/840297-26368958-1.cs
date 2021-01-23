    public virtual void MethodWithDependencies() {
        loggingProvider.Log();
        crmProvider.Crm();
        cacheProvider.Cache();
    }
