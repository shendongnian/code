    [ProtoContract]
    public class TestMessage 
    {
        [ProtoMember(1)]
        public string specificationversion;
    
        // ignore
        public bool ProductCodeSpecified;
    
        [ProtoMember(2)]
        public string SubText;
    
        [ProtoMember(3)]
        public List<byte[]> Index;
    
        [ProtoMember(4)]
        public bool Complete;
    
        public object Item;
    
        [ProtoMember(5)]
        public InfoType info;
    }
