    public class SingleOrEnumerableJsonConverter<TEnumerable> : JsonConverter
            where TEnumerable : IEnumerable
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(TEnumerable).IsAssignableFrom(objectType);
        }
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = serializer.Deserialize<JToken>(reader);
            return ConvertObject(obj) ?? GetDefaultValue();
        }
        
        private object GetDefaultValue()
        {
            return Activator.CreateInstance<TEnumerable>();
        }
        
        private object ConvertObject(JToken obj)
        {
            try
            {
                return obj.ToObject<TEnumerable>();
            }
            catch (JsonSerializationException)
            {
                // try as an array of object
                return new JArray { obj }.ToObject<TEnumerable>();
            }
        }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            object serializableValue = GetSerializableValue((TEnumerable)value, serializer);
            serializer.Serialize(writer, serializableValue);
        }
        
        private object GetSerializableValue(TEnumerable items, JsonSerializer serializer)
        {
            var arr = new JArray(items.Cast<object>()
                .Select(item => JToken.FromObject(item, serializer))
            );
            return arr.Count > 1 ? arr : arr.SingleOrDefault();
        }
    }
