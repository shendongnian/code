    public CustomList<T> : IList<T>, IList
    {
        // IList<T>
        public void Add(T value) { ... }
        // IList
        int IList.Add(object value) { this.Add((T)value); return this.Count - 1; }
        // etc
    }
