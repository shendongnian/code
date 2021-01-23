    void Main()
    {
        var deserializerSettings = new JsonSerializerSettings()
        {
            DateFormatHandling = DateFormatHandling.IsoDateFormat,
            DateParseHandling = Newtonsoft.Json.DateParseHandling.None,
            DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc
        };
        var json = "{\"inception_date\": \"0001-01-01T00:00:00+00:00\"}";
        var parsedObj = JsonConvert.DeserializeObject<TestClass>(json, deserializerSettings);
        Console.WriteLine(parsedObj);
    
        deserializerSettings = new JsonSerializerSettings()
        {
            DateFormatHandling = DateFormatHandling.IsoDateFormat,
            DateParseHandling = Newtonsoft.Json.DateParseHandling.DateTimeOffset
        };
        parsedObj = JsonConvert.DeserializeObject<TestClass>(json, deserializerSettings);
        Console.WriteLine(parsedObj);
    }
    public class TestClass
    {
        public DateTime inception_date {get;set;}
    }
