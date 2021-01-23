    [JsonConverter(typeof(LaxPropertyNameMatchingConverter))]
    public class MyClass
    {
        public string MyProperty { get; set; }
        public string MyOtherProperty { get; set; }
    }
