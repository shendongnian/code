    public class IsoDateConverter : IsoDateTimeConverter
    {
        public IsoDateConverter() => 
            this.DateTimeFormat = Culture.DateTimeFormat.ShortDatePattern;
    }
    
    public class Foo
    {
        [JsonConverter(typeof(IsoDateConverter))]
        public DateTimeOffset Date { get; set; }
    }
