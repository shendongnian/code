    public class TupleConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            var match = Regex.Match(objectType.Name, "Tuple`([0-9])", RegexOptions.IgnoreCase);
            return match.Success;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            try
            {
                var tupleTypes = objectType.GetProperties().ToList().Select(p => p.PropertyType).ToArray();
                var jObject = Newtonsoft.Json.Linq.JObject.Load(reader);
                var valueItems = new List<object>();
                for (var i = 1; i <= tupleTypes.Length; i++)
                    valueItems.Add(jObject[$"m_Item{i}"].ToObject(tupleTypes[i - 1]));
                var converterInstance = objectType.GetConstructor(tupleTypes)?.Invoke(valueItems.ToArray());
                return converterInstance;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
