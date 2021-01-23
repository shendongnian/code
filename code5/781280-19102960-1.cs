    public DoSomethingDog : Dog
    {
        Dog _parent;
        public DoSomethingDog( Dog parent )
        {
            _parent = parent;
        }
        public void DoSomething()
        {
            _parent.Bark();
        }
    }
    public DoSomethingCat : Cat
    {
        Cat _parent;
        public DoSomethingCat( Cat parent )
        {
            _parent = parent;
        }
        public void DoSomething()
        {
            _parent.Meow();
        }
    }
