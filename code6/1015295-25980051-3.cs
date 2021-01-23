    public class Repository : IRepository
    {
        ...
        public IEnumerable<T> GetAll<T>()
            where T : class
        {
            return context.Set<T>();
        }
    }
