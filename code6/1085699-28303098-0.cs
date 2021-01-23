    public class LazySessionFactoryProxy : ISessionFactory
    {
        private readonly Lazy<ISessionFactory> factory;
        public LazySessionFactoryProxy(Lazy<ISessionFactory factory) {
            this.factory = factory;
        }
        public ISession OpenSession() {
            return this.factory.Value.OpenSession();
        }
    }
