    public class Bar
    {
        public Bar(IFoo foo)
        {
            Extensions.Foo(foo);
        }
        public Bar(IFoo2 foo)
        {
            Extensions.Foo(foo, false);
        }
    }
