    class A
    {
        private readonly Lazy<B> _b = new Lazy<B>(() => new B());
        public void Method1()
        {
            B b = _b.Value;
            // Do stuff with b
        }
        public void Method2()
        {
            B b = _b.Value;
            // Do stuff with b
        }
        public void Method3()
        {
            B b = _b.Value;
            // Do stuff with b
        }
    }
