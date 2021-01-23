    public interface IReadOnlyFoo
    {
        int SomeValue
        {
            get;
        }
    }
    public class Foo: IReadOnlyFoo
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
        public IReadOnlyFoo Foo
        {
            get
            {
                return foo;
            }
        }
    }
