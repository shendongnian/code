    public IDoSomething
    {
        void DoSomething()
        {
        }
    }
    public DoSomethingFactory
    {
        public static IDoSomething( Animal parent )
        {
            if ( typeof( parent ) is Dog )
                return new DoSomethingDog( parent as Dog );
            if ( typeof( parent ) is Cat )
                return new DoSomethingCat( parent as Cat );
            return null;
        }
    }
    public DoSomethingDog : Dog, IDoSomething
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
    public DoSomethingCat : Cat, IDoSomething
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
