	// Matching type name (I[TypeName] = [TypeName]) or matching type name + suffix Adapter (I[TypeName] = [TypeName]Adapter)
	// and not decorated with the [ExcludeFromAutoRegistrationAttribute].
	CommonConventions.RegisterDefaultConventions(
		(interfaceType, implementationType) => this.Container.RegisterType(
			interfaceType, implementationType, new ContainerControlledLifetimeManager()),
		new Assembly[] { siteMapProviderAssembly },
		allAssemblies,
		excludeTypes,
		string.Empty);
	// Multiple implementations of strategy based extension points (and not decorated with [ExcludeFromAutoRegistrationAttribute]).
	CommonConventions.RegisterAllImplementationsOfInterface(
		(interfaceType, implementationType) => this.Container.RegisterType(
			interfaceType, implementationType, implementationType.Name, 
			new ContainerControlledLifetimeManager()),
		multipleImplementationTypes,
		allAssemblies,
		excludeTypes,
		string.Empty);
