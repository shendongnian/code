    public class ScopedTestClass : IDisposable
    {
      private TransactionScope TxnScope;
      public ScopedTestClass()
      {
        TxnScope = new TransactionScope();
      }
      public void Dispose()
      {
        TsnScope.Dispose();
      }
    }
