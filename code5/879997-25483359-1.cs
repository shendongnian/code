    using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
    {
        using (ObjectContext db = new ObjectContext())
        {
        
        }
    }
