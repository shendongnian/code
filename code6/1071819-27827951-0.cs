    class Foo
    {
        [JsonConverter(typeof(OmitPropertiesConverter), "SomeValue")]
        public SharedClass Shared { get; set; }
    }
    class Bar
    {
        public SharedClass Shared { get; set; }
    }
    class SharedClass
    {
        public string SomeValue { get; set; }
        public string SomeOtherValue { get; set; }
    }
