    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        JToken jToken = JToken.FromObject(value);
        if (jToken.Type == JTokenType.Object)
        {
            JObject jObject = (JObject)jToken;
            ...
            AddRemoveSerializedProperties(jObject, val);
            ...
        }
        ...
    }
