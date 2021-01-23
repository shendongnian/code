	// IMPORTANT: Must give arrays of object a name in Unity in order for it to resolve them.
	// Register the sitemap node providers
	this.Container.RegisterInstance<ISiteMapNodeProvider>("xmlSiteMapNodeProvider1", this.Container.Resolve<XmlSiteMapNodeProviderFactory>().Create(this.Container.Resolve<IXmlSource>("file1XmlSource")), new ContainerControlledLifetimeManager());
	this.Container.RegisterInstance<ISiteMapNodeProvider>("reflectionSiteMapNodeProvider1", this.Container.Resolve<ReflectionSiteMapNodeProviderFactory>().Create(includeAssembliesForScan), new ContainerControlledLifetimeManager());
	this.Container.RegisterType<ISiteMapNodeProvider, CompositeSiteMapNodeProvider>(new InjectionConstructor(new ResolvedArrayParameter<ISiteMapNodeProvider>(
		new ResolvedParameter<ISiteMapNodeProvider>("xmlSiteMapNodeProvider1"),
		new ResolvedParameter<ISiteMapNodeProvider>("reflectionSiteMapNodeProvider1"),
		new CustomSiteMapNodeProvider())));
