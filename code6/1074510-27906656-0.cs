    try
    {
        sqlTransaction = sqlConnection.BeginTransaction();
    
        //call insert in loop
    
        sqlTransaction.Commit();
    }
    catch{
        sqlTransaction.Rollback();
    }
