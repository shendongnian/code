    class CustomConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(RootObject));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            RootObject obj = new RootObject();
            obj.RecsInDB = jo["recsindb"].ToString();
            obj.RecsOnPage = jo["recsonpage"].ToString();
            obj.Orders = new Dictionary<string, Order>();
            foreach (JProperty prop in jo.Properties())
            {
                if (prop.Name != "recsindb" && prop.Name != "recsonpage")
                {
                    obj.Orders.Add(prop.Name, prop.Value.ToObject<Order>());
                }
            }
            return obj;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
