    class A
    {
        public IEnumerable<B> Bs
        {
            get
            {
                yield return new B();
            }
        }
    }
    class B
    {
        public string SomeString
        {
            get { return "Foo"; }
        }
    }
