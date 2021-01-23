    public ProviderFactory(Func<Type, object> createFunc, IProviderConfigurationService pcs)
    {
        _createFunc = createFunc; 
    }
    public Collection<IProvider> GetProviderInstances(SearchType searchType)
    {
        var providerList = _providerConfigurationService.GetProviderList(searchType);
        return new Collection<IProvider>(providerList.Select(_createFunc).ToList());
    }
