    DatabaseDataContext.Instance.sqlConnection.Open();
    sqlTransaction = sqlConnection.BeginTransaction("Example Insert users");
    try{
        // ...your first transaction
        sqlTransaction.Commit();
    }
    catch{sqlTransaction.Rollback();}
    sqlTransaction = sqlConnection.BeginTransaction("Update baked breads");
    try{
        // ...your second transaction
        sqlTransaction.Commit();
    }
    catch{sqlTransaction.Rollback();}
    // Close the connection at some point
    sqlConnection.Close();
