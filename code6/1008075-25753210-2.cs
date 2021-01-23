    public class IntFlags
    {
        public int Value { get; private set; }
        private IntFlags(int value)
        {
            this.Value = value;
        }
        public static readonly IntFlags A = new IntFlags(1);
        public static readonly IntFlags B = new IntFlags(2);
        public static readonly IntFlags C = new IntFlags(4);
        public static IntFlags operator |(IntFlags first, IntFlags second)
        {
            return new IntFlags(first.Value | second.Value);
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as IntFlags);
        }
        public override bool Equals(IntFlags obj)
        {
            return obj != null && Value == obj.Value;
        }
    }
