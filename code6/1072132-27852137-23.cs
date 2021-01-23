    public class NameValueJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(NameValueCollection).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token == null)
                return existingValue;
            NameValueCollection collection = (NameValueCollection)existingValue;
            NameValueCollectionDictionaryWrapper dictionary;
            if (token.Type != JTokenType.Object)
            {
                // Old buggy name value collection format in which the values were not written and so cannot be recovered.
                dictionary = new NameValueCollectionDictionaryWrapper();  // EMPTY DICTIONARY
            }
            else
            {
                dictionary = token.ToObject<NameValueCollectionDictionaryWrapper>();
            }
            if (dictionary == null)
                return collection;
            if (collection == null)
                collection = dictionary.GetCollection();
            else
                collection.Add(dictionary.GetCollection());
            return collection;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
                return;
            var collection = (NameValueCollection)value;
            var dictionary = new NameValueCollectionDictionaryWrapper(collection);
            serializer.Serialize(writer, dictionary);
        }
    }
