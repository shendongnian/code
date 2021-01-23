    interface IFooBar
    {
        string A { get; set; }
        string B { get; set; }
    }
    class FooAdapter : IFooBar
    {
        private readonly Foo _foo;
        public FooAdapter(Foo foo)
        {
            _foo = foo;
        }
        public string A
        {
            get { return _foo.A; }
            set { _foo.A = value; }
        }
        public string B
        {
            get { return _foo.B; }
            set { _foo.B = value; }
        }
    }
    class BarAdapter : IFooBar
    {
        private readonly Bar _bar;
        public BarAdapter(Bar bar)
        {
            _bar = bar;
        }
        public string A
        {
            get { return _bar.A; }
            set { _bar.A = value; }
        }
        public string B
        {
            get { return _bar.B; }
            set { _bar.B = value; }
        }
    }
