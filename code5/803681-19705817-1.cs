    public class FooFacade  {
        private Foo foo;
        public void SetFoo(Foo f) { foo = f; }
        // for each property:
        public X Y { get { return foo.Y; } }
    }
