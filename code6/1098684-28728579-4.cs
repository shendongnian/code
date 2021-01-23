    public interface IIsDeleted
    {
        bool IsDeleted { get; }  // Corresponds it "isDeleted" property in the JSON.
    }
    public class IsDeletetedItemSkippingCollectionConverter<T> : JsonConverter where T : IIsDeleted
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
                var obj = serializer.Deserialize<T>(reader);
                if (obj == null || obj.IsDeleted)
                {
                    var disposable = obj as IDisposable;
                    if (disposable != null)
                        disposable.Dispose();
                    continue;
                }
                list.Add(obj);
            }
            return list;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
