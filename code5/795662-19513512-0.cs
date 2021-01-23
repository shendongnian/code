    using System;
    using System.IO;
    using ProtoBuf;
    using ProtoBuf.Meta;
    
    [ProtoContract]
    [ProtoInclude(3, typeof(Foo))]
    class Base
    {
        [ProtoMember(1)]
        protected int counter = 0;
    
        public Base(int c) { counter = c; }
        public Base() { }
    }
    
    [ProtoContract]
    class Foo : Base
    {
        public int Counter { get { return counter; } }
    }
    
