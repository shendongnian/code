    [JsonConverter(typeof(MyClassConverter))]
    public class MyClass
    {
        public int Id { get; set; }
        public byte[] Logo { get; set; }
    }
