    // I. here we inherit from more sophisticated class, created for us
    internal class StringNullConverter<T> : CustomCreationConverter<T>
        where T : new()
    {
        // II. thanks the new() constraint we can override this method easily
        public override T Create(Type objectType)
        {
            return new T();
        }
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(string)) || (objectType == typeof(List<string>));
        }
        // III. here we pass the rest to smart base
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                return null;
            }
            // this is the correct implementation
            return base.ReadJson(reader, objectType, existingValue, serializer);
        }
        // unchanged
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
        }
    }
