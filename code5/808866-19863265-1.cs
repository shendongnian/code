    (dbContext as IObjectContextAdapter).ObjectContext.Connection.Open();
    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
        {
            // perform a list of queries
            // The connection will not close!
            scope.Complete();
            (dbContext as IObjectContextAdapter).ObjectContext.Connection.Close();
        }
