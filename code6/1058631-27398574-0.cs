    [DataContract]
    public class MyClass
    {
        [DataMember]
        public int Id { get; set; }
    
        [DataMember(EmitDefaultValue = false)]
        public string Name { get; set; }
    }
