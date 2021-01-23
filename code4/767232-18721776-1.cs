    public class DummyConverter<T> : JsonConverter
    {
        Action<T> _action = null;
        public DummyConverter(Action<T> action)
        {
            _action = action;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TempClass);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            serializer.Converters.Remove(this);
            T item = serializer.Deserialize<T>(reader);
            _action( item);
            return null;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
