    public interface IUnitOfWork
    {
        IUnitOfWorkSession Begin(); // starts a session and transaction
    }
    public interface IUnitOfWorkSession : IDisposable
    {
       void Commit();
       void Dispose(); // performs rollback in case no commit was performed
    }
