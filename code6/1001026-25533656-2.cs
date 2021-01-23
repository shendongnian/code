    public class ScopedTestClass
    {
      private TransactionScope TxnScope;
      public ScopedTestClass()
      {
        TxnScope = new TransactionScope();
      }
    }
