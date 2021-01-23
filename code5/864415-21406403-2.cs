    class MyDynType : System.Dynamic.DynamicObject
    {
        public int Value { get; set; }
        public static implicit operator MyDynType(int value)
        {
            MyDynType x = new MyDynType();
            if (value > 100)
                x.Value = 100;
            else
                x.Value = value;
            return x;
        }
    }
