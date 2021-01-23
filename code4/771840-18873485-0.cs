    [DataContract]
    public class User
    {
        // IsRequired and EmitDefaultValue default to 'true',
        // if not set explicitly
        [DataMember]
        public string Name { get; set; }
        
        [DataMember(IsRequired=false,EmitDefaultValue=false)]
        public Foo MyFoo { get; set; }
        ...
    }
