    public class InterfaceFactory : IInterfaceFactory
    {
        private readonly IUnityContainer container;
        public InterfaceFactory(IUnityContainer container)
        {
            this.container = container;
        }
        public IInterface Create<T>()
        {
            return this.container.Resolve<Class<T>>();
        }
    }
