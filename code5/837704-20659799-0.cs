    public class SomeEntity
    {
        public int ID { get; set; }
        public string SomeProperty { get; set; }
        [ConcurrencyCheck] 
        [Timestamp]
        public byte[] Version { get; set; }
    }
