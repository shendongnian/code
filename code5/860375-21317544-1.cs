    internal class MyDataJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(MyData<,>);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Note: this is strictly for serializing, deserializing is a whole other
            // ball of wax that I don't currently need!
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var obj = value as IEnumerable<dynamic>;
            object[][] dataArray = (from dp in obj
                                    select new object[] { dp.Item1, dp.Item2 }).ToArray();
            var ser = new JsonSerializer();
            ser.Serialize(writer, dataArray);
        }
        public override bool CanRead
        {
            get
            {
                return false;
            }
        }
    }
