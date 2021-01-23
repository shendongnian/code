    interface IFoo { }
    class Impl : IFoo { }
    class DecoratorA : IFoo
    {
        public DecoratorA(IFoo decorated) { }
    }
    class DecoratorB : IFoo
    {
        public DecoratorB(IFoo decorated) { }
    }
