    public class QValueJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(AbstractQValue).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, 
            Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            if (jo["__class__"].ToString() == "QuantitativeValue")
            {
                return jo.ToObject<QuantitativeValue>();
            }
            return jo.ToObject<QualitativeValue>();
        }
        public override void WriteJson(JsonWriter writer, 
            object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
