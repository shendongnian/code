    public class Bar
    {
        private IFoo _foo;
        public Bar(IFooFactory fooFactory)
        {
            _foo = fooFactory.Create(this);
        }
    }
