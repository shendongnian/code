    public class MyObject
    {
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime Date {get;set;}
    }
