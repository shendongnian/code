    class IdOnlyConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsClass;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Id");
            writer.WriteValue(GetId(value));
            writer.WriteEndObject();
        }
        private int GetId(object obj)
        {
            PropertyInfo prop = obj.GetType().GetProperty("Id", typeof(int));
            if (prop != null && prop.CanRead)
            {
                return (int)prop.GetValue(obj, null);
            }
            return 0;
        }
        
        public override bool CanRead 
        { 
            get { return false; } 
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
