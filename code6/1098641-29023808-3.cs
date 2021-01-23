    class A
    {
        public IEnumerable<B> List
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
