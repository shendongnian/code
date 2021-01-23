    class DictionaryWrapperConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(MyWrapper));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            MyWrapper wrapper = (MyWrapper)value;
            FieldInfo field = typeof(MyWrapper).GetField("values", BindingFlags.NonPublic | BindingFlags.Instance);
            JObject jo = JObject.FromObject(field.GetValue(wrapper));
            jo.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            MyWrapper wrapper = new MyWrapper();
            FieldInfo field = typeof(MyWrapper).GetField("values", BindingFlags.NonPublic | BindingFlags.Instance);
            field.SetValue(wrapper, jo.ToObject(field.FieldType));
            return wrapper;
        }
    }
