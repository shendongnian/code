    config.Formatters.Clear();
    var jsonFormatter = new JsonMediaTypeFormatter
    {
        // Use camel case formatting.
        SerializerSettings =
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
        }
    };
    config.Formatters.Add(jsonFormatter);
