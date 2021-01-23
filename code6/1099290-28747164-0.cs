    public class FooProxy : IFoo
    {
        private Foo _Foo;
        public FooProxy(Foo foo)
        {
            _Foo = foo;
        }
        public int FooValue
        {
            get {return _Foo.FooValue();
        }
    }
    
    public interface IFoo
    {
        public int FooValue {get;}
    }
