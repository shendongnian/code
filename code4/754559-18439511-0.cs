    public class FooRegistry : Registry {
        public FooRegistry() {
            For<IFoo>().Use<Foo>();
        }
    }
