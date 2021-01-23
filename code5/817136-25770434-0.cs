    public abstract class RepoFake : IRepo
    {
        public IA<T> Reserve<T>()
        {
            return (IA<T>)ReserveProxy(typeof(T));
        }
        
        // This will be mocked, you can call Setup with it
        public abstract object ReserveProxy(Type t);
        // TODO: add abstract implementations of any other interface members so they can be mocked
    }
