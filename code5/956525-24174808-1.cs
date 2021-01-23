    public static void Main()
    {
        using (FileStream stream = File.OpenRead("TextFile1.txt"))
        using (StreamReader reader = new StreamReader(stream))
        {
            JsonSerializer ser = new JsonSerializer();
            List<MyField> result = ser.Deserialize<List<MyField>>(new JsonTextReader(reader));
        }       
    }
    
    
        
    
        
    public class MyField
    {
        public string type { get; set; }        
        public List<MyValue> values { get; set; }
    }
    
        
    public class MyValue
    {
        [JsonConverter(typeof(MyConverter))]
        public object value { get; set; }
    }
    
    public class MyAttributes
    {
        public string text { get; set; }
        public string color { get; set; }
    }
    
    
    public class MyConverter : JsonConverter
    {
    
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                return serializer.Deserialize<string>(reader);
            }
            else
            {
                return serializer.Deserialize<MyAttributes>(reader);
            }
        }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
