    public class UnixTimestampJsonConverter : JsonConverter
    {
        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            long ts = serializer.Deserialize<long>(reader);
            
            return TimeUtils.GetMbtaDateTime(ts);
        }
        
        public override  bool CanConvert(Type type)
        {
            return typeof(DateTime).IsAssignableFrom(type);
        }
        
        public override void WriteJson(
            JsonWriter writer,
            object value,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        
        public override bool CanRead
        { 
            get { return true; } 
        }
    }
