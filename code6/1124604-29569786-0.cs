    class B
    {
        private readonly A a;
        public B(A a)
        {
            this.a = a;
        }
        public int Foo() //Example use
        {
            return 1 + a.CountMyBs();
        }
    }
    class A
    {
        public List<B> myBs = new List<B>();
        public A()
        {
            myBs.Add(new B(this)); //Pass the current A to B
        }
        public int CountMyBs()
        {
            return myBs.Count;
        }
    }
