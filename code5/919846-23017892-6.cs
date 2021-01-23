    class ResultConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Result));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load the JSON for the Result into a JObject
            JObject jo = JObject.Load(reader);
            
            // Read the properties which will be used as constructor parameters
            int? code = (int?)jo["Code"];
            string format = (string)jo["Format"];
            
            // Construct the Result object using the non-default constructor
            Result result = new Result(code, format);
            
            // (If anything else needs to be populated on the result object, do that here)
            
            // Return the result
            return result;
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
