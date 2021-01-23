    class Program
    {
        static void Main(string[] args)
        {
            string json = @"{ ""Color"": 16711680 }";
            JObject obj = JObject.Parse(json);
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new ColorConverter());
            Color c = obj["Color"].ToObject<System.Drawing.Color>(serializer);
            Console.WriteLine(c.ToString());
        }
    }
    class ColorConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(System.Drawing.Color));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((System.Drawing.Color)value).ToArgb());
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return System.Drawing.Color.FromArgb(Convert.ToInt32(reader.Value));
        }
    }
