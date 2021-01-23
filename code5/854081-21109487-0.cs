	public static void Generate(IEnumerable<Type> types)
	{
		var model = RuntimeTypeModel.Default;
		foreach (var type in types)
		{
			int counter = 1;
			var metaType = model.Add(type, false);
			var properties = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
			foreach (var propertyInfo in properties)
			{
				metaType.Add(counter++, propertyInfo.Name);
			}
		}
	}	
