    [Serializable]
    public class DatabaseSessionScopeAttribute : MethodInterceptionAspect
    {
        [NonSerialized]
        private Lazy<IDatabaseSessionProvider> databaseSessionProvider;
        public override void RuntimeInitialize(MethodBase method)
        {
            base.RuntimeInitialize(method);
            databaseSessionProvider = 
                new Lazy<IDatabaseSessionProvider>(SomeSessionProviderFactoryMethod);
        }
        private static IDatabaseSessionProvider SomeSessionProviderFactoryMethod()
        {
            return ServiceLocator.Resolve<IDatabaseSessionProvider>();
        }
    }
