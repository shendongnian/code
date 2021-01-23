    [JsonObject]
    internal abstract class DynamicMessage : DynamicObject
    {
        [JsonExtensionData]
        public Dictionary<string, object> dynamicProperties = 
                                                 new Dictionary<string, object>();
        ...
    }
