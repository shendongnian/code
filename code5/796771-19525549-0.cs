    class A
    {
        private B b;
        public A(B bType)
        {
            this.b = bType;
        }
    }
    class B
    { 
    }
    class C
    {
        private B b = new B();
        private A a;
        public C()
        {
            a = new A(b);
            a = null; // b is still alive
        }
    }
