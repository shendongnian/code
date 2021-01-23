    var obj = JsonConvert.DeserializeObject<Account>(json,new MyConverter());
.
    public class MyConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType == typeof(string) && reader.TokenType == JsonToken.StartArray)
            {
                List<long> nums = new List<long>();
                reader.Read();
                while (reader.TokenType != JsonToken.EndArray)
                {
                    nums.Add((long)reader.Value);
                    reader.Read();
                }
                return String.Join(",", nums);
            }
            return existingValue;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    public class AdAccount
    {
        public long account_id { get; set; }
        public string currency { get; set; }
        public string capabilities { get;set; }
    }
