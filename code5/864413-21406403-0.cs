    class MyDynType
    {
        public int Value { get; set; }
        public static implicit operator MyDynType(int value)
        {
            if (value > 100) throw new Exception("Value cannot be greater than 100");
            MyDynType x = new MyDynType();
            x.Value = value;
            return x;
        }
    }
