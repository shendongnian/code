    class Foo
    {
        private List<T> bar;
        private IList<T> readonlyBar;
        public Foo()
        {
            bar = ...;
            readonlyBar = bar.AsReadOnly();
        }
        public IList<T> Bar
        {
            get { return readonlyBar; }
        }
    }
