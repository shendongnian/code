    SqlTransaction transaction = null;
    SqlConnection connection = null;
    string localConnString =System.Web.Configuration.WebConfigurationManager..;
    try
    {
     connection = new SqlConnection(localConnString);
     connection.Open();
     transaction=connection.BeginTransaction();
     string insertSomeValues = "some SQL INSERT query"..
     using (SqlCommand command = new SqlCommand(insertSomeValues, connection,transaction))
     {   
      ..
     }
     using(SqlCommand newCommand = new SqlCommand(otherQuery, connection,transaction))
     {
      ..
     }
     transaction.Commit();
      }
      catch
     {
      transaction.Rollback();
      }
      finally
      {
        connection.Close();
      } 
