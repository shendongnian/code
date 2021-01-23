    public class FooFactory
    {
        public void CreateFoo()
        {
            var d = ServiceLocator.Current.GetInstance<IDependency>();
            return new Foo(d);
        }
    }
    public class Foo
    {
        public Foo(IDependency dep)
        {
        }
    }
