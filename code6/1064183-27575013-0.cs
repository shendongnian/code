    public class JsonDataConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(data));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            data returnVal = null;
             // You may need to debug this and see which token type is being returned
             // per data element and adjust, but the principle stands.
             if (reader.TokenType == JsonToken.String)
             {
                 returnVal = new data();
                 returnVal.raw = reader.ReadAsString();
             }
            else
            {
                returnVal = serializer.Deserialize<data>(reader);
            }
            return returnVal;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        { 
            // Assuming you only need to deserialize
            throw new NotImplementedException();
        }
    }
