    class JsonFieldListConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(List<JsonField>));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JObject containerObj = new JObject();
            foreach (JsonField field in (List<JsonField>)value)
            {
                JObject itemObj = new JObject();
                itemObj.Add("Value", JToken.FromObject(field.Value));
                itemObj.Add("OtherParam", new JValue(field.OtherParam));
                containerObj.Add(field.Key, itemObj);
            }
            containerObj.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
