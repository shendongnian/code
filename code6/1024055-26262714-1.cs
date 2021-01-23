    [ProtoContract]
    public class TempClass 
    {
        [ProtoMember(1)]
        public Dictionary<string, int> data;
    
        [ProtoMember(2)]
        public string Version;
    
        public TempClass() { }
    }
