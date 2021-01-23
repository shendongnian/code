    var pr = new ProjectDto();
    pr.CurrentStatus = Status.Active;
    pr.StatusEnum = typeof(Status);
    
    var settings = new JsonSerializerSettings();
    settings.Converters = new JsonConverter[] 
    {
        new EnumTypeConverter(),
        new EnumValueConverter()
    };
    settings.Formatting = Newtonsoft.Json.Formatting.Indented;
    
    string serialized = JsonConvert.SerializeObject(pr, settings);
