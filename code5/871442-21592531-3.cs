    public T deepClone<T>(T toClone) where T : class
    {
        JsonSerializerSettings settings = new JsonSerializerSettings();
        settings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
        DefaultContractResolver dcr = new DefaultContractResolver();
        dcr.DefaultMembersSearchFlags |= System.Reflection.BindingFlags.NonPublic;
        settings.ContractResolver = dcr;
        string tmp = JsonConvert.SerializeObject(toClone, settings);
        return JsonConvert.DeserializeObject<T>(tmp);
    }
