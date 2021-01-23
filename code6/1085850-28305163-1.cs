    JsonSerializerSettings JsonSettings = new JsonSerializerSettings()
    {
        TypeNameHandling = TypeNameHandling.Objects,
        DateFormatHandling = DateFormatHandling.IsoDateFormat,
        DateTimeZoneHandling = DateTimeZoneHandling.Utc,
        NullValueHandling = NullValueHandling.Ignore,
        Converters = new[] { new VersionConverter() }
    };
    
    
    var ver = new Version(1000, 1);
    var str = JsonConvert.SerializeObject(
                  ver, Newtonsoft.Json.Formatting.Indented, JsonSettings);
    
    var ver2 = JsonConvert.DeserializeObject<Version>(str, JsonSettings); 
