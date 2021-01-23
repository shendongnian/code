    class Foo
    {
        public long Value1 { get; set; }
        public float Value2 { get; set; }
        public float Value3 { get; set; }
        public unsafe Foo(Data* data)
        {
            Value1 = data->Value1;
            Value2 = data->Value2;
            Value3 = data->Value3;
        }
    }
