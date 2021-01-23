    public class SerializationConverter : JsonConverter
    {
        public override bool CanRead { get { return false; } }
        public override bool CanWrite { get { return true; } }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Form) || typeof(Form).IsAssignableFrom(objectType);
        }
        private HashSet<Form> serializedForms = new HashSet<Form>();
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Form f = (Form)value;
            
            JObject jo = new JObject();
            jo.Add("Id", f.Id);
            if (serializedForms.Add(f))
            {
                jo.Add("Field", f.Field);
                if (f.NestedObject != null)
                {
                    jo.Add("NestedObject", JToken.FromObject(f.NestedObject, serializer));
                }
            }
            jo.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
