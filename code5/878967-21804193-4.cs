    public class MyCustomConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MyCustomType);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // read the string array and convert it to dictionary 
            // as declared in your MyCustomType
            var arr = serializer.Deserialize<List<string>>(reader);
            return arr.ToDictionary(x => x, x => x);
        }
    }
