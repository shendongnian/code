    class NodeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Node));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Node node = (Node)value;
            JObject jo = new JObject();
            jo.Add("name", node.Name);
            if (node.Children.Count == 0)
            {
                jo.Add("leaf", true);
            }
            else
            {
                jo.Add("children", JArray.FromObject(node.Children, serializer));
            }
            jo.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
