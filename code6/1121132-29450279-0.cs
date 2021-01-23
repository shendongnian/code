    public class JsonSingleOrEmptyArrayConverter<T> : JsonConverter where T : class
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }
        public override bool CanWrite { get { return false; } }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (existingValue == null)
            {
                var contract = serializer.ContractResolver.ResolveContract(objectType);
                existingValue = contract.DefaultCreator();
            }
            switch (reader.TokenType)
            {
                case JsonToken.StartArray:
                    {
                        var jArray = JArray.Load(reader);
                        if (jArray == null)
                            return null;
                        switch (jArray.Count)
                        {
                            case 0:
                                existingValue = null;
                                break;
                            case 1:
                                using (var sr = new StringReader(jArray[0].ToString()))
                                {
                                    serializer.Populate(sr, existingValue);
                                }
                                break;
                            default:
                                throw new InvalidOperationException("Too many objects");
                        }
                    }
                    break;
                case JsonToken.StartObject:
                    serializer.Populate(reader, existingValue);
                    break;
                default:
                    throw new InvalidOperationException("Unexpected token type " + reader.TokenType.ToString());
            }
            return existingValue;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
