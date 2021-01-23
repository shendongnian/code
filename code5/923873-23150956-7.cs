	// Prepare for our node providers
	var rootXmlSource = this.For<IXmlSource>().Use<FileXmlSource>()
	   .Ctor<string>("fileName").Is(HostingEnvironment.MapPath("~/Root.sitemap"));
	var staffXmlSource = this.For<IXmlSource>().Use<FileXmlSource>()
	   .Ctor<string>("fileName").Is(HostingEnvironment.MapPath("~/Staff.sitemap"));
	var clientXmlSource = this.For<IXmlSource>().Use<FileXmlSource>()
	   .Ctor<string>("fileName").Is(HostingEnvironment.MapPath("~/Client.sitemap"));
	// Register the sitemap node providers
	var siteMapNodeProvider = this.For<ISiteMapNodeProvider>().Use<CompositeSiteMapNodeProvider>()
		.EnumerableOf<ISiteMapNodeProvider>().Contains(x =>
		{
			x.Type<XmlSiteMapNodeProvider>()
				.Ctor<bool>("includeRootNode").Is(true)
				.Ctor<bool>("useNestedDynamicNodeRecursion").Is(false)
				.Ctor<IXmlSource>().Is(rootXmlSource);
			x.Type<XmlSiteMapNodeProvider>()
				.Ctor<bool>("includeRootNode").Is(false)
				.Ctor<bool>("useNestedDynamicNodeRecursion").Is(false)
				.Ctor<IXmlSource>().Is(staffXmlSource);
			x.Type<XmlSiteMapNodeProvider>()
				.Ctor<bool>("includeRootNode").Is(false)
				.Ctor<bool>("useNestedDynamicNodeRecursion").Is(false)
				.Ctor<IXmlSource>().Is(clientXmlSource);
			x.Type<ReflectionSiteMapNodeProvider>()
				.Ctor<IEnumerable<string>>("includeAssemblies").Is(includeAssembliesForScan)
				.Ctor<IEnumerable<string>>("excludeAssemblies").Is(new string[0]);
		});
