    class JSONSubTestClass2Converter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(JSONSubTestClass2));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JSONSubTestClass2 jstc2 = (JSONSubTestClass2)value;
            JObject jo = new JObject();
            jo.Add(jstc2.id, JObject.FromObject(jstc2.info));
            jo.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
