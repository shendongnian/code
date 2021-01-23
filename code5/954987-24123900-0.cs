    public class FooWebService
    {
        private readonly ISomeDependency dependency;
        public FooWebService(ISomeDependency dependency)
        {
            //this is what you call during your testing
            this.dependency = dependency;
        }
        public FooWebService() : this(new ConcreteDependencyImplementation())
        {
        }
    }
