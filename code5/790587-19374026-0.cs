    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            Converters = serializer.Converters.Where(s => !(s is TypeInfoConverter)).ToList()
            // (also copy any other custom settings from the serializer you wish to pass 
            // through, such as NullValueHandling, DateFormatHandling, Formatting, etc.)
        };
        var localSerializer = JsonSerializer.Create(settings);
        var jObject = JObject.FromObject(value, localSerializer);
        jObject.AddFirst(new JProperty("Type", value.GetType().Name));
        jObject.WriteTo(writer);
    }
