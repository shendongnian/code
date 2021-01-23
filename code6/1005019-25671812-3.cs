    class NodeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Node));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            Node node = new Node();
            node.vr = (string)jo["vr"];
            if (node.vr == "PN")
            {
                node.Value = jo["Value"].ToObject<List<PnItem>>(serializer);
            }
            else if (node.vr == "SQ")
            {
                node.Value = jo["Value"].ToObject<List<Dictionary<string, Node>>>(serializer);
            }
            else
            {
                node.Value = jo["Value"].ToObject<List<string>>(serializer);
            }
            return node;
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
