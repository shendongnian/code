    public class MyObject
    {
        [JsonConverter(typeof(UnknownObjectConverter))]
        public object MyValue { get; set; }
    }
