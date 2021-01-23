    public class MyDynamicClass : DynamicObject
    {
        [JsonProperty("MyNormalProperty")]
        public string MyNormalProperty { get; set; }
    }
