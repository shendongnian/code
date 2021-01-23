    public class NameValueJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(NameValueCollection).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            NameValueCollectionDictionaryWrapper dictionaryWrapper;
            if (reader.TokenType != JsonToken.StartObject)
            {
                // Old buggy name value collection format in which the values were not written and so cannot be recovered.
                // Skip the token and all its children.
                reader.Skip();
                dictionaryWrapper = new NameValueCollectionDictionaryWrapper();  // EMPTY DICTIONARY
            }
            else
            {
                dictionaryWrapper = serializer.Deserialize<NameValueCollectionDictionaryWrapper>(reader);
            }
            NameValueCollection collection = (NameValueCollection)existingValue;
            if (dictionaryWrapper == null)
                return collection;
            if (collection == null)
                collection = dictionaryWrapper.GetCollection();
            else
                collection.Add(dictionaryWrapper.GetCollection());
            return collection;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var collection = (NameValueCollection)value;
            var dictionaryWrapper = new NameValueCollectionDictionaryWrapper(collection);
            serializer.Serialize(writer, dictionaryWrapper);
        }
    }
