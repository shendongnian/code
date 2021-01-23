    class A
    {
        public List<B> myBs = new List<B>();
        public A()
        {
            var someB = new B();
            myBs.Add(someB);
            someB.Foo(CountMyBs());
        }
        public int CountMyBs()
        {
            return myBs.Count;
        }
    }
    class B
    {
        public int Foo(int count) //Example use
        {
            return 1 + count;
        }
    }
