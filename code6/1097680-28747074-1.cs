    public class SomeService : ISomeService
    {
        private readonly IDependencyResolver _resolver;
        public SomeService(IDependencyResolver resolver)
        {
            _resolver = resolver;
        }
        public void Execute()
        {
            var logger = _resolver.GetService<ILogReporting>();
            // .... code....
        }
    }
