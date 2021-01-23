    public class TestClass
    {
        const string DefaultStringValue = "This is a default string value";
        public string Property1 { get; set; }
        public string Property2 { get; set; }
        public static void Test()
        {
            var settings = new JsonSerializerSettings { ContractResolver = new DefaultStringValueContractResolver(DefaultStringValue) };
            var test = JsonConvert.DeserializeObject<TestClass>("{}", settings);
            Debug.Assert(test.Property1 == DefaultStringValue && test.Property2 == DefaultStringValue); // No assert
            Debug.WriteLine(JsonConvert.SerializeObject(test)); // Prints {"Property1":"This is a default string value","Property2":"This is a default string value"}
        }
    }
