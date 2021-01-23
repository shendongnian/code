    class A
    {
        private int f1;
        private int f2;
        public A()
        {
           ...
        }
        public A(A original)
        {
            f1 = original.f1;
            f2 = original.f2;
        }
    }
    
    class B<T> : A
    {
        public B(A original) : base(original)
        {
        }
        // Possibly overload with a B(B<T> original) as well?
    }
