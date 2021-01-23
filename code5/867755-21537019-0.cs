	type = Type.GetType(typename,
		assemblyName =>
		{
			return AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(a => a.GetName().Name == assemblyName.Name);
		},
		(assembly, typeName, caseInsensitive) =>
		{
			if (caseInsensitive)
				return assembly.GetTypes().SingleOrDefault(t => t.FullName.Equals(typeName, StringComparison.InvariantCultureIgnoreCase));
			else
				return assembly.GetTypes().SingleOrDefault(t => t.FullName == typeName);
		});
