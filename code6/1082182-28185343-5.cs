    class Transaction<T> where T : IDepartmentEntity
    {
        public bool Success { get; private set; }
        public T Entity { get; private set; }
        public Transaction(bool success, T entity)
        {
            Success = success;
            Entity = entity;
        }
        public void GenerateOutput() { Entity.GenerateOutput(); }
    }
