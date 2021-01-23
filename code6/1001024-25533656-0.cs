    public class ScopedTestClass
    {
      private TransactionScope TxnScope;
      public ScopedTestCase()
      {
        TxnScope = new TransactionScope();
      }
    }
