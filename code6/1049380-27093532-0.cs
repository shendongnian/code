    class UnknownObjectConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                JObject jo = JObject.Load(reader);
                string typeName = (string)jo["$type"];
                Type type = Type.GetType(typeName);
                if (type != null)
                {
                    return jo.ToObject(type, serializer);
                }
            }
            catch
            {
            }
            return null;
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
