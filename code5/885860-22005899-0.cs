    public class ObjectConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            // Use this converter for vanilla objects.
            return objectType == typeof(object);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Simply load a JObject from the reader and return it.
            // This will preserve the $type property if present.
            return JObject.Load(reader);
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
