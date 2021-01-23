    public class DeletetedItemSkippingCollectionConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<T>);
        }
        public override bool CanWrite { get { return false; } }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var list = (existingValue as List<T>);
            if (list == null)
                list = new List<T>();
            if (reader.TokenType != JsonToken.StartArray)
                return list;
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.EndArray)
                    break;
                // Load each object from the stream and do something with it
                var obj = JObject.Load(reader);
                var deleted = obj["isDeleted"];
                if (deleted != null)
                {
                    if (deleted.Type == JTokenType.Boolean && (bool)deleted)
                        continue;
                }
                if (obj != null)
                {
                    list.Add((T)obj.ToObject<T>(serializer));
                }
            }
            return list;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
