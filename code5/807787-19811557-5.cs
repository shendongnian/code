    public class SampleJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, 
            object value, JsonSerializer serializer)
        {
            Sample sample = (Sample)value;
            JToken t = JToken.FromObject(new { 
                          sample.name, 
                          sample.myclass.p1, 
                          sample.myclass.p2 
                       });
            t.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType,
            object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Sample);
        }
    }
