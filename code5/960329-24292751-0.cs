    var json = @"{""SomeValue"":""x"",""SomeStringValue"":""y""}";
    var obj = JsonConvert.DeserializeObject<SomeObject>(json);
---
    public class MyConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return new WrappedString((string)reader.Value);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    public class SomeObject
    {
        [JsonConverter(typeof(MyConverter))]
        public WrappedString SomeValue { get; set; }
        public string SomeStringValue { get; set; }
    }
    public class WrappedString
    {
        public readonly string Value;
        public WrappedString(string value)
        {
            Value = value;
        }
    }
