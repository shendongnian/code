    string json = @"{""date_created"":1375206707}";
            
    var obj = JsonConvert.DeserializeObject<TempClass>(json,new DateConverter());
---
    public class TempClass
    {
        public DateTime date_created;
    }
    public class DateConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return new DateTime(1970, 1, 1).AddSeconds((long)reader.Value);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
