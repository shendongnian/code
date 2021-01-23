    class A
    {
        public int X { get; set; }
    }
    class B
    {
        public int Twice(A a) 
        {
            return a.X * 2;
        }
    }
