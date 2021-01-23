    SqlConnection connection = null;
    try
    {
        connection = new SqlConnection(...);
        //all other stuff goes here
    }
    catch{}
    finally
    {
       if(connection != null)
          connection.Close(); //This will always close the connection, even with exceptions.
    }
 
