    interface I2<T> where T : I1
    {
        T ABC { get; set; }
    }
    class ClassOfI2 : I2<ClassOfI1>
    {
        public ClassOfI1 ABC { get; set; }
    }
