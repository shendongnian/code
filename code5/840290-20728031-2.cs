    class DictionaryConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            Throw(new NotImplementedException());            
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Your code to deserialize the json into a dictionary object.
            
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Throw(new NotImplementedException());   
        }
    }
