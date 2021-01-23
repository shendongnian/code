    class SetConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            // this converter can handle converting some JSON to a List<string>
            return objectType == typeof(List<string>);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Convert an array of arrays of strings to a flat list of strings
            JArray array = JArray.Load(reader);
            return array.Children<JArray>()
                .SelectMany(ja => ja.Children(), (ja, jt) => jt.Value<string>()).ToList();
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
