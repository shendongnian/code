        public class DefaultJsonConverter : JsonConverter
        {
            [ThreadStatic]
            private static bool _isReading;
    
            [ThreadStatic]
            private static bool _isWriting;
    
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                try
                {
                    _isWriting = true;
    
                    Property typeHintProperty = TypeHintPropertyForType(value.GetType());
    
                    var jObject = JObject.FromObject(value, serializer);
                    if (typeHintProperty != null)
                    {
                        jObject.AddFirst(typeHintProperty);
                    }
                    writer.WriteToken(jObject.CreateReader());
                }
                finally
                {
                    _isWriting = false;
                }
            }
    
            public override bool CanWrite
            {
                get
                {
                    if (!_isWriting)
                        return true;
    
                    _isWriting = false;
    
                    return false;
                }
            }
    
            public override bool CanRead
            {
                get
                {
                    if (!_isReading)
                        return true;
    
                    _isReading = false;
    
                    return false;
                }
            }
    
            public override bool CanConvert(Type objectType)
            {
                return true;
            }
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                try
                {
                    _isReading = true;
                    return serializer.Deserialize(reader, objectType);
                }
                finally
                {
                    _isReading = false;
                }
            }
        }
