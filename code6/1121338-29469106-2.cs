    public class A
    {
        public string NameOfA { get; set; }
    
        [JsonIgnore]
        public string IgnoredProperty { get; set; }
    
        [JsonIgnore]
        public B B { get; set; }
    }
    
    public class B
    {
        public string NameOfB { get; set; }
    }
