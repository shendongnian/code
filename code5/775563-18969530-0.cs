    public class FooWithConstructorAndPropertyDependency : IFoo
    {
        public FooWithConstructorAndPropertyDependency(IBar bar)
        {
            Bar = bar;
        }
        public IBar Bar { get; set; }
    }
