    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonProperty(PropertyName = "$BagData")]
        public BagData BagData { get; set; }
    }
