    struct MyInt
    {
        static readonly int[] legalValues = { 3, 6, 8, 11 };
        public int Value
        {
            get;
            private set;
        }
        public bool IsIllegal
        {
            get
            {
                return Value == 0;
            }
        }
        MyInt(int value)
            : this()
        {
            Value = value;
        }
        public static implicit operator MyInt(int value)
        {
            if (legalValues.Contains(value))
            {
                return new MyInt(value);
            }
            return new MyInt();
        }
    }
