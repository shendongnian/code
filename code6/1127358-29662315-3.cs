    [DataContract]
    public class MyBaseClass
    {
        public string MyProperty { get; set; }
    }
    
    [DataContract]
    public class MyChildClass : MyBaseClass
    {
        [DataMember]
        public string MyProperty2 { get; set; }
    }
