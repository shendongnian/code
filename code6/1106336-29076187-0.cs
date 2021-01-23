    try
    {
        Transaction.Rollback();
        Connection.Dispose();
        Connection = null;
    }
    catch (Exception ex2)
    {                                                      
        throw new AggregateException(new List<Exception>() { e, ex2 });
    }
