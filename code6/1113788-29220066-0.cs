	var allAssemblies = new Assembly[] { currentAssembly, siteMapProviderAssembly };
	var excludeTypes = new Type[] { 
		// Use this array to add types you wish to explicitly exclude from convention-based  
		// auto-registration. By default all types that either match I[TypeName] = [TypeName] or 
		// I[TypeName] = [TypeName]Adapter will be automatically wired up as long as they don't 
		// have the [ExcludeFromAutoRegistrationAttribute].
		//
		// If you want to override a type that follows the convention, you should add the name 
		// of either the implementation name or the interface that it inherits to this list and 
		// add your manual registration code below. This will prevent duplicate registrations 
		// of the types from occurring. 
		// Example:
		// typeof(SiteMap),
		// typeof(SiteMapNodeVisibilityProviderStrategy)
	};
	var multipleImplementationTypes = new Type[]  { 
		typeof(ISiteMapNodeUrlResolver), 
		typeof(ISiteMapNodeVisibilityProvider), // <- These are automatically registered by convention
		typeof(IDynamicNodeProvider) 
	};
    // ...
	// Multiple implementations of strategy based extension points (and not decorated with [ExcludeFromAutoRegistrationAttribute]).
	CommonConventions.RegisterAllImplementationsOfInterface(
		(interfaceType, implementationType) => this.Container.RegisterType(interfaceType, implementationType, implementationType.Name, new ContainerControlledLifetimeManager()),
		multipleImplementationTypes,
		allAssemblies,
		excludeTypes,
		string.Empty);
