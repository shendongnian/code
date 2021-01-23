    class ItemListConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(List<Item>));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken response = JToken.Load(reader)["response"];
            if (response.Type == JTokenType.Array)
            {
                return response.ToObject<List<Item>>();
            }
            else
            {
                return response["items"].ToObject<List<Item>>();
            }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
