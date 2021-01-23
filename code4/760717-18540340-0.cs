    var entity = new Foo();
    var json = JsonConvert.SerializeObject(entity, new DateTimeWrapperConverter());
---
    public class DateTimeWrapperConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTimeWrapper);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            //Left as an exercise to the reader :)
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var obj = value as DateTimeWrapper;
            serializer.Serialize(writer, obj.DateTime);
        }
    }
