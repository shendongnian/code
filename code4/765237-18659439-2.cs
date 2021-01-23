    var obj = new OuterClass();
    //The code above
    public class OuterClass
    {
        public InnerClass prop = new InnerClass();
    }
    public class InnerClass
    {
        [JsonIgnore]
        public string prop1 = "1111";
        [JsonProperty("PROP-2")]
        public string prop2 = "2222";
        public string prop3 = "3333";
    }
