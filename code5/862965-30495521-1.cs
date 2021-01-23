    class FooConverter : JsonConverter
    {
        bool _canWrite = true;
        public override bool CanWrite
        {
            get { return _canWrite;}
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
                _canWrite = false;
                jo = JObject.FromObject(foo);
                _canWrite = true;
            }
            jo.WriteTo(writer);
        }
    }
