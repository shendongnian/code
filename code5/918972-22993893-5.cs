        JsonSerializerSettings settings = new JsonSerializerSettings();
        settings.Formatting = Formatting.Indented;
        if (useLongNames)
        {
            settings.ContractResolver = new OriginalNameContractResolver();
        }
        string response = JsonConvert.SerializeObject(obj, settings);
