	bool visibilityAffectsDescendants = false;
	// Module code omitted here...
	
	// Visibility Providers
	this.For<ISiteMapNodeVisibilityProviderStrategy>().Use<SiteMapNodeVisibilityProviderStrategy>()
		.Ctor<string>("defaultProviderName").Is("MvcSiteMapProvider.FilteredSiteMapNodeVisibilityProvider, MvcSiteMapProvider");
