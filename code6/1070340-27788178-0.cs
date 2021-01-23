	// IMPORTANT: Must give arrays of object a name in Unity in order for it to resolve them.
	// Register the sitemap node providers
	this.Container.RegisterInstance<ISiteMapNodeProvider>("xmlSiteMapNodeProvider1", this.Container.Resolve<XmlSiteMapNodeProviderFactory>().Create(this.Container.Resolve<IXmlSource>("file1XmlSource")), new ContainerControlledLifetimeManager());
	this.Container.RegisterInstance<ISiteMapNodeProvider>("reflectionSiteMapNodeProvider1", this.Container.Resolve<ReflectionSiteMapNodeProviderFactory>().Create(includeAssembliesForScan), new ContainerControlledLifetimeManager());
	// Register your custom SiteMapNodeProvider, and give it a name (required).
	this.Container.RegisterType<ISiteMapNodeProvider, CustomSiteMapNodeProvider>("customSiteMapNodeProvider");
	this.Container.RegisterType<ISiteMapNodeProvider, CompositeSiteMapNodeProvider>(new InjectionConstructor(new ResolvedArrayParameter<ISiteMapNodeProvider>(
		new ResolvedParameter<ISiteMapNodeProvider>("xmlSiteMapNodeProvider1"),
		new ResolvedParameter<ISiteMapNodeProvider>("reflectionSiteMapNodeProvider1"),
		// Resolve your custom SiteMapNodeProvider instance.
		// Note the name must match the name above, and naming the registration is required in
		// Unity in order to resolve more than one implementation of an interface.
		new ResolvedParameter<ISiteMapNodeProvider>("customSiteMapNodeProvider"))));
