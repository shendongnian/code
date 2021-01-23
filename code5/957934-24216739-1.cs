    public interface IReadOnlyFoo
    {
        int GetSomeValue
        {
            get;
        }
    }
    public class Foo: IReadOnlyFoo
    {
        public int GetSomeValue
        {
            get;
            private set;
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
