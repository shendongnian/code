    class DirConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Dir));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Dir dir = (Dir)value;
            JObject obj = new JObject();
            if (dir.Files.Count > 0)
            {
                JArray files = new JArray();
                foreach (string name in dir.Files)
                {
                    files.Add(new JValue(name));
                }
                obj.Add("files", files);
            }
            foreach (var kvp in dir.Dirs)
            {
                obj.Add(kvp.Key, JToken.FromObject(kvp.Value, serializer));
            }
            obj.WriteTo(writer);
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
