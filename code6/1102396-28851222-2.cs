    public interface IUow : IDisposable
    {
        IDBContext DBC { get; set; }
        ...
    }
