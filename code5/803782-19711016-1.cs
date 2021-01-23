    public abstract class MyJsonConverter<T> : JsonConverter
    {
        protected abstract T Create(Type objectType, JObject jObject);
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }
        public override object ReadJson
            (JsonReader reader, 
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            T target = Create(objectType, jObject);
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }
        public override void WriteJson
            (JsonWriter writer, 
            object value, 
            JsonSerializer serializer)
        {
            //
        }
    }
