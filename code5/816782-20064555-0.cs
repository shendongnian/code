    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var myType = value as MyType;
        if (myType != null)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("myProperty");
            serializer.Serialize(writer, myType.myProperty); // Using this will allow to serialize inner values with CamelCasePropertyNamesContractResolver
            writer.WritePropertyName("Inner");
            serializer.Serialize(writer, myType.Inner);
          ...
            writer.WriteEndObject();
        }
    }
