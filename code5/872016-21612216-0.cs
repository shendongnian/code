    container.RegisterSingle<ReflectionSiteMapNodeProvider>(() => container.GetInstance<ReflectionSiteMapNodeProviderFactory>()
        .Create(includeAssembliesForScan));
    // Register the sitemap builders
    container.RegisterSingle<ISiteMapBuilder>(() => container.GetInstance<SiteMapBuilderFactory>()
        .Create(new CompositeSiteMapNodeProvider(container.GetInstance<XmlSiteMapNodeProvider>(), container.GetInstance<ReflectionSiteMapNodeProvider>())));
