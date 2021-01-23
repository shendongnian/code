	var type = typeof (IDataTypeConverter<>);
	var types = AppDomain.CurrentDomain.GetAssemblies()
		.SelectMany(x => x.GetTypes())
		.Where(x => !x.IsInterface) //ignore interface definitions
		.Where(x => x.GetInterfaces() //for each interface implemented
			.Where(i => i.IsGenericType) //if they're a generic interface
			.Any(i => i.GetGenericTypeDefinition() == type)); //check its open-generic
