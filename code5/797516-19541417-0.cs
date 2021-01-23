    IDbConnection someConnection = new ....
    var transaction = someConnection.BeginTransaction(TransactionScope.Serializable);
    try
    {
        IDbCommand cmd = someConnection.GetCommand();
        cmd.Transaction = transaction;
        ...
        cmd.ExecuteNonQuery();
        foreach(var data in subdata)
        {
            IDbCommand subcmd = someConnection.GetCommand();
            subcmd.Transaction = transaction;
            ...
            subcmd.ExecuteNonQuery();
        }
        ...
        transaction.Commit();
    }
    catch(Exception e)
    {
        transaction.Rollback();
    }
