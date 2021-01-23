    public struct MyStruct
    {
        // Note: must explicitly call parameterless constructor
        public MyStruct(int prop1, int prop2)
            : this()
        {
            Prop1 = prop1;
            Prop2 = prop2;
        }
        public int Prop1 { get; set; }
        public int Prop2 { get; set; }
    }
