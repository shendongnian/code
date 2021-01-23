    class KvpConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(KeyValuePair<string, object>);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var kvp = (KeyValuePair<string, object>)value;
            JObject jo = new JObject();
            jo.Add(kvp.Key, JToken.FromObject(kvp.Value, serializer));
            jo.WriteTo(writer);
        }
        public override bool CanRead
        {
            get { return false; }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
