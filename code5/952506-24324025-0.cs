    public TransactionScope BeginTransactionScope()
    {
        return new TransactionScope();
    }
    public void CommitTransactionScope(TransactionScope scope)
    {
        scope.Complete();
        scope.Dispose();  // simulates leaving the using { ... } scope
    }
    public void RollbackTransactionScope(TransactionScope scope)
    {
        scope.Dispose();  // simulates leaving the using { ... } scope
    }
    // Does some work using Connections and maybe nested scopes
    public void DoSomeWork1() { ... }
    public void DoSomeWork2() { ... }
    public void DoSomeWork3() { ... }
