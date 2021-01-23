    public class YearInfoConverter : JsonConverter
    {
    
        public override bool CanConvert(Type objectType)
        {
            return typeof(JsonConverter) == objectType;
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
    
            var year = jObject["year"].Value<int>();
            var yearInfo = existingValue ?? Activator.CreateInstance(objectType, year);
    
            List<MonthInfo> months = new List<MonthInfo>();
            foreach (var item in (jObject as IEnumerable<KeyValuePair<string, JToken>>).Skip(1))
            {
                months.Add(new MonthInfo()
                {
                    Name = item.Key,
                    Value = item.Value.Value<int>()
                });
            }
    
            objectType.GetProperty("Months").SetValue(yearInfo, months);
    
            return yearInfo;
        }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            //we just want to deserialize the object so we don't need it here, but the implementation would be very similar to deserialization
        }
    }
