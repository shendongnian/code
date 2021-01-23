    [DataContract]
    [KnownType(typeof(TestClassTwo))]
    public class TestClass
    {
       [DataMember]
       public int Group { get; set; }
    
       [DataMember]
       public List<TestClassTwo> Member { get; set; }
    }
