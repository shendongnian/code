    class MyDictionaryConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Dictionary<string, T>));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray array = JArray.Load(reader);
            Dictionary<string, T> dict = new Dictionary<string, T>();
            foreach (JObject obj in array.Children<JObject>())
            {
                string key = obj["Key"].ToString();
                T val = obj["Value"].ToObject<T>();
                dict.Add(key, val);
            }
            return dict;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Dictionary<string, T> dict = (Dictionary<string, T>)value;
            JArray array = new JArray();
            foreach (KeyValuePair<string, T> kvp in dict)
            {
                JObject obj = new JObject();
                obj.Add("Key", kvp.Key);
                obj.Add("Value", JToken.FromObject(kvp.Value));
                array.Add(obj);
            }
            array.WriteTo(writer);
        }
    }
