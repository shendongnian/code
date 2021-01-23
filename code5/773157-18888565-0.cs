    [DataContract(IsReference = true)]
    class Foo
    {
        [DataMember(Order = 1)]
        public Foo Parent { get; set; }
    }
