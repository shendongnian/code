    public class MyObjectChildObjectConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ChildObject);
        }
        
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = serializer.Deserialize<JToken>(reader);
            switch (obj.Type)
            {
            case JTokenType.Object:
                return ReadAsObject(obj as JObject);
            case JTokenType.String:
                return ReadAsString((string)(JValue)obj);
            default:
                throw new JsonSerializationException("Unexpected token type");
            }
        }
        
        private object ReadAsObject(JObject obj)
        {
            return obj.ToObject<ChildObject>();
        }
        
        private object ReadAsString(string str)
        {
            // do a lookup for the actual object or whatever here
            return new ChildObject
            {
                Id = str,
            };
        }
    }
