    public abstract class Base
    {
        public string Type { get; set; }
    }
    
    class Foo : Base
    {
        public string FooProperty { get; set; }
    }
    
    class Bar : Base
    {
        public string BarProperty { get; set; }
    }
    
    class CustomSerializableConverter : CustomCreationConverter<Base>
    {
        public override Base Create(Type objectType)
        {
            throw new NotImplementedException();
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
    
            var type = (string)jObject.Property("Type");
            Base target;
            switch (type)
            {
                case "Foo":
                    target = new Foo();
                    break;
                case "Bar":
                    target = new Bar();
                    break;
                default:
                    throw new InvalidOperationException();
            }
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var json = "[{Type:\"Foo\",FooProperty:\"A\"},{Type:\"Bar\",BarProperty:\"B\"}]";
            List<Base> bases = JsonConvert.DeserializeObject<List<Base>>(json, new CustomSerializableConverter());
        }
    }
