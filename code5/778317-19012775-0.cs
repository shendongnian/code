    [ProtoContract]
    public class DynamicWrapper
    {
        [ProtoMember(1)]
        public List<DictWrapper> Items { get; set; }
    
        public DynamicWrapper()
        {
            Items = new  List<DictWrapper>();
        }
    }
    [ProtoContract]
    public class DictWrapper
    {
        [ProtoMember(1)]
        public Dictionary<string, string> Dictionary { get; set; }
    }
