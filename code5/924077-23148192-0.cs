    IReadRepository<out T>
    {
        IEnumerable<T> GetItems();
        T GetItem(int id);
    }
    IWriteRepository<in T>
    {
        void AddItem(T item);
    }
