    class UsefulBFactory : BFactory
    {
        public UsefulAFactory(Func<A> newA)
        {
            this.newA = newA;
        }
        Func<A> newA;
        public B CreateB()
        {
            return new B(newA());
        }
    }
