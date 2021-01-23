    sDomain = AppDomain.CreateDomain(DOMAIN_NAME);
    sDomain.DoCallBack(AppDomainCallback);
    
    // runs in the context of the AppDomain
    private void AppDomainCallback()
    {
      Assembly assembly = Assembly.LoadFrom(mAssemblyName);
    }
