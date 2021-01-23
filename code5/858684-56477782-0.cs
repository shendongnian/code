    var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
	var toBeSerialized = settings; // use the settings as an example data to be serialized
	var serialized = JsonConvert.SerializeObject(toBeSerialized, Formatting.Indented, settings);
	var deserialized = JsonConvert.DeserializeObject(serialized, settings);
	var deserializedType = deserialized.GetType().Name; // JsonSerializerSettings
