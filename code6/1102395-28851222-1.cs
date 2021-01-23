    class UnitOfWork : IUow, IDisposable
    {
        public IDBContext DBC { get; set; }
        ...
    }
