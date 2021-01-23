    public class DataListConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Data);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken array = JToken.Load(reader);
            List<Data> list = new List<Data>();
            foreach (JArray data in array.Children<JArray>())
            {
                list.Add(new Data
                {
                    Date = data[0].ToObject<DateTime>(),
                    Open = data[1].ToObject<double?>(),
                    High = data[2].ToObject<double?>(),
                    Low = data[3].ToObject<double?>(),
                    Last = data[4].ToObject<double?>(),
                    Change = data[5].ToObject<double?>(),
                    Settle = data[6].ToObject<double?>(),
                    Volume = data[7].ToObject<int?>(),
                    OpenInterest = data[8].ToObject<int?>()
                });
            }
            return list;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
