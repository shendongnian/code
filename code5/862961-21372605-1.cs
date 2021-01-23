    class FooConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Foo).IsAssignableFrom(objectType);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Foo foo = (Foo)value;
            JObject jo;
            if (foo.IsSpecial)
            {
                // special serialization logic based on instance-specific flag
                jo = new JObject();
                jo.Add("names", string.Join(", ", new string[] { foo.A, foo.B, foo.C }));
            }
            else
            {
                // normal serialization
                jo = JObject.FromObject(foo);
            }
            jo.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
