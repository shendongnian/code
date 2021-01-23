    JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
    serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    serializerSettings.Converters.Add(new SomeItemConverter());
    var jsonContent = JsonConvert.SerializeObject(dl, serializerSettings);
    Console.WriteLine(jsonContent);
