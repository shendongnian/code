        public class MvcSiteMapProviderContainerExtension
                : UnityContainerExtension
        {
        	protected override void Initialize()
        	{
        		bool securityTrimmingEnabled = false;
        		bool enableLocalization = true;
        
        		string rootSiteMapFile = HostingEnvironment.MapPath("~/Mvc.sitemap");
        		string adminSiteMapFile = HostingEnvironment.MapPath("~/Areas/Admin/Mvc.sitemap");
        
        		TimeSpan absoluteCacheExpiration = TimeSpan.FromMinutes(5);
        		string[] includeAssembliesForScan = new string[] { "MccSiteMapProviderTest" };
        
        		var currentAssembly = this.GetType().Assembly;
        		var siteMapProviderAssembly = typeof(SiteMaps).Assembly;
        		var allAssemblies = new Assembly[] { currentAssembly, siteMapProviderAssembly };
        		var excludeTypes = new Type[] {
        			typeof(SiteMapNodeVisibilityProviderStrategy),
        			typeof(SiteMapXmlReservedAttributeNameProvider),
        			typeof(SiteMapBuilderSetStrategy),
        			typeof(SiteMapNodeUrlResolverStrategy),
        			typeof(DynamicNodeProviderStrategy)
        		};
        		var multipleImplementationTypes = new Type[] {
        			typeof(ISiteMapNodeUrlResolver),
        			typeof(ISiteMapNodeVisibilityProvider),
        			typeof(IDynamicNodeProvider)
        		};
        
        // Single implementations of interface with matching name (minus the "I").
        		CommonConventions.RegisterDefaultConventions(
        			(interfaceType, implementationType) => this.Container.RegisterType(interfaceType, implementationType, new ContainerControlledLifetimeManager()),
        			new Assembly[] { siteMapProviderAssembly },
        			allAssemblies,
        			excludeTypes,
        			string.Empty);
        
        // Multiple implementations of strategy based extension points
        		CommonConventions.RegisterAllImplementationsOfInterface(
        			(interfaceType, implementationType) => this.Container.RegisterType(interfaceType, implementationType, implementationType.Name, new ContainerControlledLifetimeManager()),
        			multipleImplementationTypes,
        			allAssemblies,
        			excludeTypes,
        			"^Composite");
        
        // TODO: Find a better way to inject an array constructor
        
        // Url Resolvers
        		this.Container.RegisterType<ISiteMapNodeUrlResolverStrategy, SiteMapNodeUrlResolverStrategy>(new InjectionConstructor(
        			new ResolvedArrayParameter<ISiteMapNodeUrlResolver>(this.Container.ResolveAll<ISiteMapNodeUrlResolver>().ToArray())
        			));
        
        // Visibility Providers
        		this.Container.RegisterType<ISiteMapNodeVisibilityProviderStrategy, SiteMapNodeVisibilityProviderStrategy>(new InjectionConstructor(
        			new ResolvedArrayParameter<ISiteMapNodeVisibilityProvider>(this.Container.ResolveAll<ISiteMapNodeVisibilityProvider>().ToArray()),
        			new InjectionParameter<string>(string.Empty)
        			));
        
        // Dynamic Node Providers
        		this.Container.RegisterType<IDynamicNodeProviderStrategy, DynamicNodeProviderStrategy>(new InjectionConstructor(
        			new ResolvedArrayParameter<IDynamicNodeProvider>(this.Container.ResolveAll<IDynamicNodeProvider>().ToArray())
        			));
        
        
        // Pass in the global controllerBuilder reference
        		this.Container.RegisterInstance<ControllerBuilder>(ControllerBuilder.Current);
        		this.Container.RegisterType<IControllerBuilder, ControllerBuilderAdaptor>(new PerResolveLifetimeManager());
        
        		this.Container.RegisterType<IBuildManager, BuildManagerAdaptor>(new PerResolveLifetimeManager());
        
        		this.Container.RegisterType<IControllerTypeResolverFactory, ControllerTypeResolverFactory>(new InjectionConstructor(
        			new List<string>(),
        			new ResolvedParameter<IControllerBuilder>(),
        			new ResolvedParameter<IBuildManager>()));
        
        // Configure Security
    
        // IMPORTANT: Must give arrays of object a name in Unity in order for it to resolve them.
                this.Container.RegisterType<IAclModule, AuthorizeAttributeAclModule>("authorizeAttribute");
                this.Container.RegisterType<IAclModule, XmlRolesAclModule>("xmlRoles");
                this.Container.RegisterType<IAclModule, CompositeAclModule>(new InjectionConstructor(new ResolvedArrayParameter<IAclModule>(
                    new ResolvedParameter<IAclModule>("authorizeAttribute"),
                    new ResolvedParameter<IAclModule>("xmlRoles"))));
    
    
    
                this.Container.RegisterType<ISiteMapCacheKeyGenerator, SiteMapCacheKeyGenerator2>();
    
    
                this.Container.RegisterInstance<System.Runtime.Caching.ObjectCache>(System.Runtime.Caching.MemoryCache.Default);
                this.Container.RegisterType(typeof(ICacheProvider<>), typeof(RuntimeCacheProvider<>));
    
                this.Container.RegisterType<ICacheDependency, RuntimeFileCacheDependency>(
                    "rootSiteMapCacheDependency", new InjectionConstructor(rootSiteMapFile));
    
                this.Container.RegisterType<ICacheDependency, RuntimeFileCacheDependency>(
                    "adminSiteMapCacheDependency", new InjectionConstructor(adminSiteMapFile));
    
                this.Container.RegisterType<ICacheDetails, CacheDetails>("rootSiteMapCacheDetails",
                    new InjectionConstructor(absoluteCacheExpiration, TimeSpan.MinValue, new ResolvedParameter<ICacheDependency>("rootSiteMapCacheDependency")));
    
                this.Container.RegisterType<ICacheDetails, CacheDetails>("adminSiteMapCacheDetails",
                    new InjectionConstructor(absoluteCacheExpiration, TimeSpan.MinValue, new ResolvedParameter<ICacheDependency>("adminSiteMapCacheDependency")));
    
    // Configure the visitors
                this.Container.RegisterType<ISiteMapNodeVisitor, UrlResolvingSiteMapNodeVisitor>();
    
    // Prepare for the sitemap node providers
                this.Container.RegisterType<IXmlSource, FileXmlSource>("rootSiteMapXmlSource", new InjectionConstructor(rootSiteMapFile));
                this.Container.RegisterType<IXmlSource, FileXmlSource>("adminSiteMapXmlSource", new InjectionConstructor(adminSiteMapFile));
        
        // IMPORTANT: Must give arrays of object a name in Unity in order for it to resolve them.
        // Register the sitemap node providers
            this.Container.RegisterInstance<ISiteMapNodeProvider>("rootXmlSiteMapNodeProvider",
                this.Container.Resolve<XmlSiteMapNodeProviderFactory>().Create(this.Container.Resolve<IXmlSource>("rootSiteMapXmlSource")), new ContainerControlledLifetimeManager());
        
            this.Container.RegisterInstance<ISiteMapNodeProvider>("adminXmlSiteMapNodeProvider",
                this.Container.Resolve<XmlSiteMapNodeProviderFactory>().Create(this.Container.Resolve<IXmlSource>("adminSiteMapXmlSource")), new ContainerControlledLifetimeManager());
        
            this.Container.RegisterInstance<ISiteMapNodeProvider>("ReflectionSiteMapNodeProvider1",
                this.Container.Resolve<ReflectionSiteMapNodeProviderFactory>().Create(includeAssembliesForScan), new ContainerControlledLifetimeManager());
        
            this.Container.RegisterType<ISiteMapNodeProvider, CompositeSiteMapNodeProvider>("rootSiteMapNodeProvider", 
                new ContainerControlledLifetimeManager(),
                new InjectionConstructor(new ResolvedArrayParameter<ISiteMapNodeProvider>(
                    new ResolvedParameter<ISiteMapNodeProvider>("rootXmlSiteMapNodeProvider"),
                    new ResolvedParameter<ISiteMapNodeProvider>("ReflectionSiteMapNodeProvider1"))));
        
            this.Container.RegisterType<ISiteMapNodeProvider, CompositeSiteMapNodeProvider>("adminSiteMapNodeProvider",
                new ContainerControlledLifetimeManager(),
                new InjectionConstructor(new ResolvedArrayParameter<ISiteMapNodeProvider>(
                    new ResolvedParameter<ISiteMapNodeProvider>("adminXmlSiteMapNodeProvider"),
                    new ResolvedParameter<ISiteMapNodeProvider>("ReflectionSiteMapNodeProvider1"))));
        
        // Configure the builders
            this.Container.RegisterInstance<ISiteMapBuilder>("rootSiteMapBuilder", 
                this.Container.Resolve<SiteMapBuilderFactory>().Create(this.Container.Resolve<ISiteMapNodeProvider>("rootSiteMapNodeProvider")), 
                new ContainerControlledLifetimeManager());
        
            this.Container.RegisterInstance<ISiteMapBuilder>("adminSiteMapBuilder", 
                this.Container.Resolve<SiteMapBuilderFactory>().Create(this.Container.Resolve<ISiteMapNodeProvider>("adminSiteMapNodeProvider")), 
                new ContainerControlledLifetimeManager());      
        
        // Configure the builder sets
            this.Container.RegisterType<ISiteMapBuilderSet, SiteMapBuilderSet>("rootBuilderSet",
                new InjectionConstructor(
                    "default",
                    securityTrimmingEnabled,
                    enableLocalization,
                    new ResolvedParameter<ISiteMapBuilder>("rootSiteMapBuilder"),
                    new ResolvedParameter<ICacheDetails>("rootSiteMapCacheDetails")));
        
            this.Container.RegisterType<ISiteMapBuilderSet, SiteMapBuilderSet>("adminBuilderSet",
                new InjectionConstructor(
                    "admin",
                    securityTrimmingEnabled,
                    enableLocalization,
                    new ResolvedParameter<ISiteMapBuilder>("adminSiteMapBuilder"),
                    new ResolvedParameter<ICacheDetails>("adminSiteMapCacheDetails")));
        	}
        }
