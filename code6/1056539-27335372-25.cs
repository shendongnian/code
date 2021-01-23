    public class MyContainer
    {
        public MyContainer()
        {
            this.Dictionary = new Dictionary<MyValue, int>();
        }
        public MyValue MyValue { get; set; }
        [JsonConverter(typeof(DictionaryToArrayConverter<MyValue, int>))]
        public Dictionary<MyValue, int> Dictionary { get; set; }
    }
    public class DictionaryToArrayConverter<TKey, TValue> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Dictionary<TKey, TValue>);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            KeyValuePair<TKey, TValue>[] pairs;
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Array)
            {
                pairs = token.ToObject<KeyValuePair<TKey, TValue>[]>(serializer);
            }
            else
            {
                JArray array = new JArray();
                array.Add(token);
                pairs = token.ToObject<KeyValuePair<TKey, TValue>[]>(serializer);
            }
            if (pairs == null)
                return null;
            return pairs.ToDictionary(pair => pair.Key, pair => pair.Value);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
                return;
            var pairs = ((IDictionary<TKey, TValue>)value).ToArray();
            serializer.Serialize(writer, pairs);
        }
    }
