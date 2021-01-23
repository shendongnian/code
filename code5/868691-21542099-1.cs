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
            node.id = (int)jo["id"];
            JToken name = jo["name"];
            if (name.Type == JTokenType.String)
            {
                // The name is a string at the current level
                node.name = (string)name;
            }
            else
            {
                // The name is one level down inside an object
                node.name = (string)name["name"];
            }
            node.children = jo["children"].ToObject<List<Node>>(serializer);
            
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
