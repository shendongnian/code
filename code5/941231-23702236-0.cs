    Mvx.RegisterSingleton(() =>
    {
        var provider = Mvx.IocConstruct<ISystemConfigProviderInitialiser>();
        return provider;
    });
    Mvx.RegisterSingleton(() =>
    {
        var provider = Mvx.Resolve<ISystemConfigProviderInitialiser>();
        if (provider == null)
        {
            throw new InvalidOperationException("ISystemConfigProviderInitialiser should be resolved first.");
        }
        return (ISystemConfigProvider)provider;
    });
