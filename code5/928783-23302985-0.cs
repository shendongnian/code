    [DataContract]
    [KnownType(typeof(SomeOtherclass.MyDerivedClass))]
    public class MyAbstractBase
    {
        [DataMember]
        public string Foo { get; set; }
    
        // some other abstract methods that derived classes have to implement
    }
