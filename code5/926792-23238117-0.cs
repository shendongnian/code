    struct MyStruct
    {
        private int someValue;
        public MyStruct(int initialValue) { someValue = initialValue; }
        public int SomeValue { get; set; } // someValue can be modified here through the setter
    }
