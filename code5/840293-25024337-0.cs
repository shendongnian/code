    class Bar : IBar
    {
    }
    class Foo : IFoo
    {
        public Foo(IBar bar)
        {
            //initialize etc.
        }
        //public methods
    }
    class Manager : IManager
    {
        public Manager(Foo foo)
        {
            //initialize etc
        }
    }
