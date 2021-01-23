    class UsefulBFactory : BFactory
    {
        public UsefulAFactory(A a)
        {
            this.a = a;
        }
        A a;
        public B CreateB()
        {
            return new B(a);
        }
    }
