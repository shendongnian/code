    public class ClassFactory : IClassFactory
    {
        private readonly IUnityContainer container;
        public ClassFactory(IUnityContainer container)
        {
            this.container = container;
        }
        public IInterface Create<T>()
        {
            return this.container.Resolve<Class<T>>();
        }
    }
