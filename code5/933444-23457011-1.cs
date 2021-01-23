    public class InterfaceProxyWithoutTargetProvider<TInterface> : IProvider<TInterface>
        where TInterface : class
    {
        private readonly IProxyGenerator proxyGenerator;
        private readonly IInterceptorFactory interceptorFactory;
        public InterfaceProxyWithoutTargetProvider(IProxyGenerator proxyGenerator, IInterceptorFactory interceptorFactory)
        {
            this.proxyGenerator = proxyGenerator;
            this.interceptorFactory = interceptorFactory;
        }
        public Type Type
        {
            get { return typeof(TInterface); }
        }
        public object Create(IContext context)
        {
   
             var interceptorTypes = context.Kernel.Get<IEnumerable<IInterceptorBindingDefinition<TInterface>>();
             IList<IInterceptor> interceptors = interceptorTypes
                  .Select(x => x.InterceptorType)
                  .Select(x => context.ContextPreservingGet(x))
                  .ToList();
            return this.proxyGenerator.CreateInterfaceProxyWithoutTarget<TInterface>(interceptors);
        }
    }
