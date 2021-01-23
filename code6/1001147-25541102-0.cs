    class RecordFileConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(RecordFile));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            RecordFile rf = new RecordFile();
            rf.Page = (string)jo["page"];
            rf.Context = (string)jo["context"];
            JObject records = (JObject)jo["records"];
            rf.RecordCount = (int)records["rCount"];
            rf.Records = records.Properties()
                                .Where(p => p.Name != "rCount")
                                .Select(p => p.Value.ToObject<Record[]>())
                                .ToList();
            return rf;
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
