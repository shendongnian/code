    class SomeItemConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsGenericType && 
                objectType.GetGenericTypeDefinition() == typeof(SomeItem<,>);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JToken token = JToken.FromObject(value);
            JObject obj = new JObject();
            obj.Add(token["Key"].ToString(), token["Value"]);
            obj.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            JProperty prop = token.Children<JProperty>().First();
            JObject obj = new JObject();
            obj.Add("Key", prop.Name);
            obj.Add("Value", prop.Value);
            return obj.ToObject(objectType);
        }
    }
