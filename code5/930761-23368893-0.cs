    public class NameAddress
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
    
    public class RootObject
    {
        [JsonProperty("123")]
        public NameAddress { get; set; }
        [JsonProperty("1412")]
        public NameAddress { get; set; }
        [JsonProperty("4123")]
        public NameAddress { get; set; }
    }
