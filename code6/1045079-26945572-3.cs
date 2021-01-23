    public class ProviderFactory : IProviderFactory
    {
        private readonly IKernel _kernel;
        public ProviderFactory(IKernel kernel)
        {
            _kernel = kernel;
        }
        public T Create<T>()
        {
            var instance = _kernel.Get<T>();
            return instance;
        }
    }
