    public class TupleConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
        
        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            List<Tuple<string, string>> result = null;
            
            if (reader.TokenType == JsonToken.StartArray)
            {            
                JArray deserialized = JArray.Load(reader);
                result = new List<Tuple<string, string>>(deserialized.Count);
                
                foreach (var token in deserialized)
                {
                    if (token.Type == JTokenType.Object)
                    {
                        result.Add(Tuple.Create(
                            token["name"].ToObject<string>(),
                            token["value"].ToObject<string>()));
                    }
                }
            }
            
            return result;
        }
        
        public override bool CanRead
        {
            get { return true; }
        }
    }
