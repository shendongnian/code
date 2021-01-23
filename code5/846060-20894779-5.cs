    class MyCustomObjectConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(ChildObject));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            ChildObject child = null;
            if (token.Type == JTokenType.String)
            {
                child = new ChildObject();
                child.Id = token.ToString();
                child.IsFullyPopulated = false;
            }
            else if (token.Type == JTokenType.Object)
            {
                child = token.ToObject<ChildObject>();
                child.IsFullyPopulated = true;
            }
            else if (token.Type != JTokenType.Null)
            {
                throw new JsonSerializationException("Unexpected token: " + token.Type);
            }
            return child;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
