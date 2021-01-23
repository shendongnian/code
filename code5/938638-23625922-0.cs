    [ProtoContract]
    public class ShortcutData {
        [ProtoMember(1)]
        public int Key {get;set;}
        [ProtoMember(2)]
        public string Link {get;set;}
    }
