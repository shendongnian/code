    using (DbProviderConnection cnctn = _planDb.CreateOpenConnection())
    {
        using (cnctn.BeginTransaction())
        {
            // ...
            cnctn.Transaction.Commit();
        } // Here BeginTransaction.Dispose() is called.
    } // Here DbProviderConnection.Dispose() is called.
