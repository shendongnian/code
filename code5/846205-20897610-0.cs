    class A : IEquatable<A>
    {
        public UInt32 Prop1 { get; set; }
        public byte Prop2 { get; set; }
        public string Prop3 { get; set; }
        public int[] Prop4 { get; set; }
        public bool Equals(A other)
        {
            return other != null
                && Prop1 == other.Prop1
                && Prop2 == other.Prop2
                && Prop3 == other.Prop3
                && System.Linq.Enumerable.SequenceEqual(Prop4, other.Prop4);
        }
    }
