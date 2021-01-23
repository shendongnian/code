    public static RootObject<T> Deserialize<T>(string json, string rootName)
    {
        JsonSerializerSettings settings = new JsonSerializerSettings();
        settings.ContractResolver = new CustomResolver(rootName);
        return JsonConvert.DeserializeObject<RootObject<T>>(json, settings);
    }
