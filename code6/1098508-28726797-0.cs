    [JsonConverter(typeof(MyCustomSerializer))]
    public class Movie
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Classification { get; set; }
        public string Studio { get; set; }
        public List<string> ReleaseCountries { get; set; }
    }
    public class MyCustomSerializer: JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteValue("{}");
            } 
            else 
            {
                base.WriteJson(writer, value, serializer);
            }
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == "{}")
            {
                return null;
            } 
            else 
            {
                return base.ReadJson(reader, objectType, existingValue, serializer);
            }
        }
    
        public override bool CanConvert(Type objectType)
        {
            return typeof(Movie).IsAssignableFrom(objectType);
        }
    }
