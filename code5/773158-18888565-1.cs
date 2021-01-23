    [ProtoContract(AsReferenceDefault = true)]
    class Foo
    {
        [ProtoMember(1)]
        public Foo Parent { get; set; }
    }
