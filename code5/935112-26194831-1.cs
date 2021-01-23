    public static void Register(HttpConfiguration config)
	{
		config.Formatters.Remove(config.Formatters.JsonFormatter);
		var serializer = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
		var formatter = new JsonMediaTypeFormatter { Indent = true, SerializerSettings =  serializer };
		config.Formatters.Add(formatter);
	}
