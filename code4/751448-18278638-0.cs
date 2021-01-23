    var obj = JsonConvert.DeserializeObject<Account>(json,new MyConverter());
.
    public class MyConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<int>);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value is string)
            {
                return ((string)reader.Value).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToList();
                 
            }
            return existingValue;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is List<int>)
            {
                writer.WriteValue(String.Join("," , (List<int>)value));
            }    
        }
    }
