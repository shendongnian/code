    interface IFilter<T>
    {
         IQueryable<T> Filter(IQueryAble<T> data);
    }
    interface IResultSet<T>
    {
        int OrignalCount { get; }
        int FilteredCount { get; }
        IEnumerable<T> Result { get; }
        void AddFilter(IFilter<T> filter);
    }
