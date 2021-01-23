    public class MyClassConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(MyClass) == objectType;
        }
        public override object ReadJson(JsonReader reader, Type objectType,
                     object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value,
                                         JsonSerializer serializer)
        {
            var myClass = (MyClass)value;
            serializer.Serialize(writer, new { Id = myClass.Id,
                                               Logo = myClass.Logo != null });
        }
    }
