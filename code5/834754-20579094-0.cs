    public sealed class UnitOfWork : IDisposable {
       private readonly TransactionScope _transaction;
       public UnitOfWork() { _transaction = new TransactionScope(); }
       public void Commit { _transaction.Commit(); }
       public void Dispose { _transaction.Dispose(); }
    }
