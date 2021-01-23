    class MyConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (writer.Path.EndsWith(".objId")) {
                writer.WriteValue(Convert.ToInt32(value) + 10);
            }
            else {
                writer.WriteValue(value);
            }
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (int);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
