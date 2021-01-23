        public class FlattenJsonConverter : JsonConverter
        {
            #region Public Methods
              
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                var jToken = JToken.FromObject(value);
                if (jToken.Type != JTokenType.Object)
                {
                    jToken.WriteTo(writer);
                    return;
                }
    
                var jObject = (JObject)jToken;
                writer.WriteStartObject();
                WriteJson(writer, jObject);
                writer.WriteEndObject();
            }
    
            private void WriteJson(JsonWriter writer, JObject value)
            {
                foreach (var property in value.Properties())
                {
                    var jObject = property.Value as JObject;
                    if (jObject != null)
                        WriteJson(writer, jObject);
                    else
                        property.WriteTo(writer);
                }
            }
    
            public override object ReadJson(JsonReader reader, Type objectType,
               object existingValue, JsonSerializer serializer)
            {
                return null;
            }
    
            public override bool CanConvert(Type objectType)
            {
                return true;
            }
    
            #endregion
        }
