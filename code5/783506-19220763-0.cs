    [ProtoContract]
    class DummySurrogate
    {
        [ProtoMember(1)]
        public int Negative { get; set; }
        [ProtoConverter]
        public static IDummy From(DummySurrogate value)
        {
            return value == null ? null : new Dummy { Positive = -value.Negative };
        }
        [ProtoConverter]
        public static DummySurrogate To(IDummy value)
        {
            return value == null ? null : new DummySurrogate
               { Negative = -value.Positive };
        }
    }
