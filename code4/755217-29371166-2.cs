    internal class OnDemandInterceptor<T> : IInterceptor
    {
        private readonly Func<IUnityContainer, T> _proxiedInstanceFactory;
        private readonly IUnityContainer _container;
        public OnDemandInterceptor(IUnityContainer container, Func<IUnityContainer, T> proxiedInstanceFactory)
        {
            _proxiedInstanceFactory = proxiedInstanceFactory;
            _container = container;
        }
        public void Intercept(IInvocation invocation)
        {
            var proxiedInstance = _proxiedInstanceFactory.Invoke(_container);
            var types = invocation.Arguments.Select(arg => arg.GetType()).ToArray();
            var method = typeof(T).GetMethod(invocation.Method.Name, types);
            invocation.ReturnValue = method.Invoke(proxiedInstance, invocation.Arguments);
        }
    }
