    public class IsoDateConverter : IsoDateTimeConverter
    {
        public IsoDateConverter() => this.DateTimeFormat = "yyyy-MM-dd";
    }
    
    public class Foo
    {
        [JsonConverter(typeof(IsoDateConverter))]
        public DateTimeOffset Date { get; set; }
    }
