    public interface IFooFactory
    {
        IFoo GetFooByName(string name);
    }
    
    public class FooFactory : IFooFactory
    {
        private readonly IKernel _kernel;
    
        public FooFactory(IKernel kernel)
        {
            _kernel = kernel;
        }
    
        public IFoo GetFooByName(string name)
        {
            return _kernel.Get<AFoo>(name);
        }
    }
