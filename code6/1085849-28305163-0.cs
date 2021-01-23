    public class VersionConverter : JsonConverter
    {
        public override void WriteJson(
            JsonWriter writer,
            object value,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        
        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            JObject obj = serializer.Deserialize<JObject>(reader);
            
            int major = obj["Major"].ToObject<int>();
            int minor = obj["Minor"].ToObject<int>();
            
            Version v = new Version(major, minor);
            
            return v;
        }
        
        public override bool CanConvert(Type objectType)
        {
            return typeof(Version).IsAssignableFrom(objectType);
        }
        
        public override bool CanWrite { get { return false; } }
    }
