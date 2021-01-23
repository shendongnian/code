    [JsonConverter(typeof(FooConverter))]
    public class Foo
    {
        public bool Bar { get; set; }
        public bool Baz { get; set; }
    }
