    //dbAdmin is my DataContext
    System.Data.Common.DbTransaction trans = null;
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
