    public class TestData
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public TestEnum Enum { get; set; }
    }
