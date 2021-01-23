	class RequiredAttribute : Attribute
	{
	}
	public T Deserialize<T>(Stream stream)
	{
		var requiredProperties = new Dictionary<object, HashSet<MemberInfo>>();
		var writerSettings = new XamlObjectWriterSettings
		{
			BeforePropertiesHandler = (sender, args) =>
			{
				var thisInstanceRequiredProperties = new HashSet<MemberInfo>();
				foreach(var propertyInfo in args.Instance.GetType().GetProperties())
				{
					if(propertyInfo.GetCustomAttribute<RequiredAttribute>() != null)
					{
						thisInstanceRequiredProperties.Add(propertyInfo);
					}
				}
				requiredProperties[args.Instance] = thisInstanceRequiredProperties;
			},
			XamlSetValueHandler = (sender, args) =>
			{
				if(!requiredProperties.ContainsKey(sender))
				{
					return;
				}
				requiredProperties[sender].Remove(args.Member.UnderlyingMember);
			},
			AfterPropertiesHandler = (sender, args) =>
			{
				if(!requiredProperties.ContainsKey(args.Instance))
				{
					return;
				}
				var propertiesNotSet = requiredProperties[args.Instance];
				if(propertiesNotSet.Any())
				{
					throw new Exception("Required property \"" + propertiesNotSet.First().Name + "\" not set.");
				}
				requiredProperties.Remove(args.Instance);
			}
		};
		var readerSettings = new XamlXmlReaderSettings
		{
			LocalAssembly = Assembly.GetExecutingAssembly(),
			ProvideLineInfo = true
		};
		using(var reader = new XamlXmlReader(stream, readerSettings))
		using(var writer = new XamlObjectWriter(reader.SchemaContext, writerSettings))
		{
			XamlServices.Transform(reader, writer);
			return (T)writer.Result;
		}
	}
