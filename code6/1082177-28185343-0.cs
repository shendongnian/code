    class Transaction<T>
    {
        public bool Success { get; private set; }
        public T Entity { get; private set; }
        public Transaction(bool success, T entity)
        {
            Success = success;
            Entity = entity;
        }
        public void GenerateOutput() { /* something goes here */ }
    }
