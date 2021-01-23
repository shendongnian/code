    public interface IRepository<T> where T : IRepositoryEntry, new()
    {
        event EventHandler<RepositoryOperationEventArgs> InsertEvent;
        event EventHandler<RepositoryOperationEventArgs> UpdateEvent;
        event EventHandler<RepositoryOperationEventArgs> DeleteEvent;
        IList<String> PrimaryKeys { get; }
        
        void Insert(T Entry);
        void Update(T Entry);
        void Delete(Predicate<T> predicate);
        bool Exists(Predicate<T> predicate);
        T Retrieve(Predicate<T> predicate);
        IEnumerable<T> RetrieveAll();
    }
