    using (var ts = new TransactionScope(TransactionScopeOption.Required,
                    new TransactionOptions {IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted}))
    {
        var result = DbContext.Executions.Where(/*...condition...*/).Sum(o=>o.ORDERQTY * o.MULTIPLIER)
    }
