    public class FooJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var foo = value as Foo;
            if (foo == null || !foo.Enabled)
                return;
            writer.WriteStartObject();
            writer.WritePropertyName("Enabled");
            serializer.Serialize(writer, foo.Enabled);
            //Write the rest of the serialization
            writer.WriteEndObject();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize(reader, objectType);
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (Foo);
        }
    }
