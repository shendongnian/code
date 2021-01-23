    var jsonSerializerSettings = new JsonSerializerSettings()
	{
		TypeNameHandling = TypeNameHandling.All,
		TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
		//Converters = new JsonConverter[] { new PropertyInfoConverter(), },
	};
	var propertyInfo = typeof(Test).GetProperty("Name");
	
	var serialized = JsonConvert.SerializeObject(PropertyInfoData.FromProperty(propertyInfo), jsonSerializerSettings);
	var deserialized = ((PropertyInfoData)JsonConvert.DeserializeObject(serialized, jsonSerializerSettings)).ToProperty();
