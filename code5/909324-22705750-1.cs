    //dbAdmin is my DataContext
    dbAdmin.Connection.Open();
    trans = dbAdmin.Connection.BeginTransaction();
    dbAdmin.Transaction = trans;
    
     try
      {
       //Perform ExecuteQuery
        trans.Commit();
      }
     catch(Exception)
      {
       // Rollback transaction
       if (trans != null)
       trans.Rollback();
       return "Some error occured while saving record. Transaction has being rollbacked.";
      }
