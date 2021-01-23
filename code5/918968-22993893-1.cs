        JsonSerializerSettings settings = new JsonSerializerSettings();
        settings.Formatting = Formatting.Indented;
        if (useLongNames)
        {
            settings.ContractResolver = new OriginalNameContractResolver();
        }
        return JsonConvert.SerializeObject(obj, settings);
