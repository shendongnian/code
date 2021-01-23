    public class Foo
    {
        [JsonProperty(Required = Required.Always)]
        public ClassA A { get; set; }
        public string B { get; set; }
    }
    public class ClassA
    {
        public string C { get; set; }
    }
