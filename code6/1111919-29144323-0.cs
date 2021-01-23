    [Serializable]
    public class DatabaseSessionScopeAttribute : MethodInterceptionAspect
    {
        [NonSerialized]
        private Lazy<IDatabaseSessionProvider> databaseSessionProvider = new Lazy<IDatabaseSessionProvider>(SomeSessionProviderFactoryMethod);
        private static IDatabaseSessionProvider SomeSessionProviderFactoryMethod()
        {
            return ServiceLocator.Resolve<IDatabaseSessionProvider>();
        }
    }
