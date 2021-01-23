    public override object ReadJson(JsonReader reader,
        Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.String)
        {
            return null;
        }
        return base.ReadJson(reader, objectType, existingValue, serializer);    
    }
