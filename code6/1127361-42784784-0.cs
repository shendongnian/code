    public class MyBaseClass
    {
        public virtual string MyProperty { get { return "Hello, world"; } }
    }
    
    public class MyChildClass : MyBaseClass
    {
        [JsonIgnore]
        public override string MyProperty { get; }
    }
