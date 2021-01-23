    try
    {
        entityTransaction = Context.Connection.BeginTransaction();
    
        //call insert in loop
    
        entityTransaction.Commit();
    }
    catch{
        entityTransaction.Rollback();
    }
