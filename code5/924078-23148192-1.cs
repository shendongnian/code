    interface IReadRepository<out T>
    {
        IEnumerable<T> GetItems();
        T GetItem(int id);
    }
    interface IWriteRepository<in T>
    {
        void AddItem(T item);
    }
