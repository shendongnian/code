    public ReadOnlyObservableCollection<T> GetReadOnlyObjectsFromDB<T>()
        where T : class
    {
        return new ReadOnlyObservableCollection<T>(dbContext.Set<T>().Local);
    }
