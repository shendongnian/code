    [ProtoContract(UseProtoMembersOnly = true, IgnoreListHandling = true)]
    public class ProtobufTest<T, P> : IDictionary<T, P>
    {
        [ProtoMember(1)]
        private readonly Dictionary<T, P> _dataset;
        [ProtoMember(2)]
        public string Name;
        private ProtobufTest(Dictionary<T, P> dataset, string name)
        {
            _dataset = dataset ?? new Dictionary<T, P>();
            Name = name;
        }
        public ProtobufTest(string name) : this(new Dictionary<T, P>(), name) { }
        private ProtobufTest() : this(null, string.Empty) {}
       
        //
        // IDictionary implementation is omitted.
        //
    }
