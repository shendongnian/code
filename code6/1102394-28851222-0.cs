    class UnitOfWork : IUow, IDisposable
    {
        public DBContext DBC { get; set; }
        ...
    }
