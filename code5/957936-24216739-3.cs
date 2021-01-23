    public class ReadOnlyFoo
    {
        private readonly Foo foo;
        public ReadOnlyFoo(Foo foo)
        {
            this.foo = foo;
        }
        public SomeReferenceType SomeValue
        {
            get
            {
                return foo.SomeValue;
            }
        }
    }
    public class Foo
    {
        public int SomeValue
        {
            get;
            set;
        }
    }
    public class Bar
    {
        private Foo foo;
        public readonly ReadOnlyFoo Foo;
        public Bar()
        {
            foo = blablabla;
            Foo = new ReadOnlyFoo(foo);
        }
    }
