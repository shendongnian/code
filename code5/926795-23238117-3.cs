    struct MyStruct
    {
        private int someValue;
        public MyStruct(int initialValue) { someValue = initialValue; }
        public int SomeValue { get; } // No way to modify someValue
    }
