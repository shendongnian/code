    class UnknownObjectConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JObject jo = new JObject();
            jo["type"] = value.GetType().AssemblyQualifiedName;
            jo["value"] = JToken.FromObject(value, serializer);
            jo.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            Type type = Type.GetType(jo["type"].ToString(), throwOnError: true);
            return jo["value"].ToObject(type, serializer);
        }
    }
