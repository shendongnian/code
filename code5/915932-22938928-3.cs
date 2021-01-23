    new JsonSerializerSettings
    {
        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        Converters = new List<JsonConverter> { new StringEnumConverter { CamelCaseText = true } },
        NullValueHandling = NullValueHandling.Ignore
    };
