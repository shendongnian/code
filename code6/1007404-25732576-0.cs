    public class ZohoDataMultiRowJson
    {
        [JsonConverter(typeof(ZohoDataRowJsonConverter))]
        public List<ZohoDataRowJson> Row { get; set; }
    }
    public class ZohoDataRowJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                return serializer.Deserialize<List<ZohoDataRowJson>>(reader);
            }
            else if (reader.TokenType == JsonToken.StartObject)
            {
                return new List<ZohoDataRowJson>
                {
                    (ZohoDataRowJson) serializer.Deserialize<ZohoDataRowJson>(reader)
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
