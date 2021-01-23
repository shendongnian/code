<!-- -->
    
    public class FooConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var foo = value as Foo;
            var obj = new object[] { foo.Bar, foo.Baz };
            serializer.Serialize(writer, obj);
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var arr = ReadArrayObject(reader, serializer);
            return new Foo
            {
                Bar = (bool)arr[0],
                Baz = (bool)arr[1],
            };
        }
        
        private JArray ReadArrayObject(JsonReader reader, JsonSerializer serializer)
        {
            var arr = serializer.Deserialize<JToken>(reader) as JArray;
            if (arr == null || arr.Count != 2)
                throw new JsonSerializationException("Expected array of length 2"); 
            return arr;
        }
    
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Foo);
        }
    }
