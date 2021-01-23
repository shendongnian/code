    public override IResourceProvider(string classKey)
    {
        var factory = (ResourceProviderFactory)Activator.CreateInstance(Type.GetType("System.Web.Compilation.ResXResourceProviderFactory, System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"));
        var provider = factory.CreateGlobalResourceProvider(classKey);
        return new CustomResourceProvider(provider);
    }
