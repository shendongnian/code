    class MyConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            foreach (var prop in value.GetType().GetProperties()) {
                writer.WritePropertyName(prop.Name);
                if (prop.Name == "objId") {
                    //modify objId values for example
                    writer.WriteValue(Convert.ToInt32(prop.GetValue(value, null)) + 10); 
                } else {
                    writer.WriteValue(prop.GetValue(value, null));
                }                
            }
            writer.WriteEndObject();
        }
        public override bool CanConvert(Type objectType)
        {
            //only attempt to handle types that have an objId property
            return (objectType.GetProperties().Count(p => p.Name == "objId") == 1);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
