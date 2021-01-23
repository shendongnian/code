    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        JToken t = serializer.DefaultFromObject(value);
        // Remainder as before
        if (t.Type != JTokenType.Object)
        {
            t.WriteTo(writer);
            return;
        }
        JObject o = (JObject)t;
        writer.WriteStartObject();
        WriteJson(writer, o);
        writer.WriteEndObject();
    }
