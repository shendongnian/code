    public class ZohoDataMultiRowJson
    {
        [JsonConverter(typeof(ArrayOrObjectConverter<ZohoDataRowJson>))]
        public List<ZohoDataRowJson> Row { get; set; }
    }
    public class ArrayOrObjectConverter<T> : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                return serializer.Deserialize<List<T>>(reader);
            }
            else if (reader.TokenType == JsonToken.StartObject)
            {
                return new List<T>
                {
                    (T) serializer.Deserialize<T>(reader)
                };
            }
            else
            {
                throw new NotSupportedException("Unexpected JSON to deserialize");
            }
        }
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
