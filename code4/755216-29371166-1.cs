    internal class OnDemandInjectionFactory<T> : InjectionFactory
    {
        public OnDemandInjectionFactory(Func<IUnityContainer, T> proxiedObjectFactory) : base((container, type, name) => FactoryFunction(container, type, name, proxiedObjectFactory))
        {
        }
        private static object FactoryFunction(IUnityContainer container, Type type, string name, Func<IUnityContainer, T> proxiedObjectFactory)
        {
            var interceptor = new OnDemandInterceptor<T>(container, proxiedObjectFactory);
            var proxyGenerator = new ProxyGenerator();
            var proxy = proxyGenerator.CreateClassProxy(type, interceptor);
            return proxy;
        }
    }
