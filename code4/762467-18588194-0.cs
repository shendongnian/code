    try
    {
    sqlConnection.Open();
    // ....
    }
    finally
    {
    if(sqlConnection != null)
          sqlConnection.Dispose();
    }
