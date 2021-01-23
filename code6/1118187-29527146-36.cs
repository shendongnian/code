    [ProtoContract]
    public struct Fred
    {
        [ProtoMember(1)]
        public string Name;
    }
    [ProtoContract]
    public struct Middle
    {
        [ProtoMember(1)]
        public Fred[] Freds;
    }
    [ProtoContract]
    public struct Top
    {
        [ProtoMember(1)]
        public Middle Middle;
        [ProtoMember(2)]
        public Fred[] Freds;
    }
