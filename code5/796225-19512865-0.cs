    class TestClassConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(TestClass) == objectType;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            string[] names = jo["Names"].ToObject<string[]>();
            return new TestClass(names);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
