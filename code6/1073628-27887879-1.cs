    [Serializable]
    [DataContract(Name = "MainClass")]
    [KnownType(typeof(Class1))]
    [KnownType(typeof(Class2))]
    public class MainClass
    {
    
        public MainClass()
        {
            Value2 = new List<Class2>();
        }
    
        [DataMember(Name = "class")]
        public Class1 Value1 { get; set; }
    
        [DataMember(Name = "classes")]
        public List<Class2> Value2 { get; set; }
    
    }
