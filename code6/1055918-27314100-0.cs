    namespace JsonRawTest
    {
        public class AConverter : JsonConverter
        {
            public override bool CanRead { get { return false; } }
            public override bool CanWrite { get { return true; } }
    
            public override object ReadJson(JsonReader reader, Type objectType,
                object existingValue, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
    
            public override void WriteJson(JsonWriter writer, object value,
                JsonSerializer serializer)
            {
                A obj = value as A;
                writer.WriteStartObject();
                writer.WritePropertyName("Prop1");
                writer.WriteValue(obj.Prop1);
                writer.WritePropertyName("Prop2");
                writer.WriteRawValue(obj.Prop2);
                writer.WriteEndObject();
            }
    
            public override bool CanConvert(Type objectType)
            {
                return typeof(A).IsAssignableFrom(objectType);
            }
        }
        
        public class A
        {
            public string Prop1 { get; set; }
            public string Prop2 { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var a = new A
                {
                    Prop1 = "Some first value",
                    Prop2 = "$.jqplot.DateAxisRenderer"
                };
    
                string json = JsonConvert.SerializeObject(a, 
                    new JsonConverter[] { new AConverter() });
                ...
            }
        }
    }
