    var res = JsonConvert.DeserializeObject<ItemResults>(json,new CustomConverter());
.
    public class CustomConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Dictionary<string, string>);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType == typeof(Dictionary<string, string>) && reader.TokenType== JsonToken.StartArray)
            {
                reader.Read(); // Read JsonToken.EndArray
                return new Dictionary<string,string>(); // or return null
            }
            serializer.Converters.Clear(); //To avoid Infinite recursion, remove this converter.
            return serializer.Deserialize<Dictionary<string,string>>(reader);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
