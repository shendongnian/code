    [ProtoContract]
    public class Foo { // in namespace X
        [ProtoMember(1)]
        public int Id {get;set;}
        [ProtoMember(2)]
        public string Name {get;set;}
    }
    ...
    [ProtoContract]
    public class User { // in namespace Y
        [ProtoMember(2)]
        public string UserName {get;set;}
    }
