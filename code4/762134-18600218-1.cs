    class FooCollectionConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(FooCollection));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            foreach (Foo foo in (FooCollection)value)
            {
                writer.WritePropertyName(GetFooKey(foo));
                serializer.Serialize(writer, foo);
            }
            writer.WriteEndObject();
        }
        // Given a Foo, return its unique key to be used during serialization
        private string GetFooKey(Foo foo)
        {
            char c = foo.Name != null ? foo.Name[0] : 'X';
            return c + foo.Id.ToString();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
