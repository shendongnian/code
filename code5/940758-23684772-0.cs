      String str;
      SqlConnection myConn = new SqlConnection ("Data Source=.\\SQLEXPRESS;Integrated Security=True;User Instance=True");
      str = "CREATE DATABASE MyDatabase ON PRIMARY " +
           "(NAME = MyDatabase_Data, " +
           "FILENAME = 'C:\\MyDatabaseData.mdf', " +
           "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
           "LOG ON (NAME = MyDatabase_Log, " +
           "FILENAME = 'C:\\MyDatabaseLog.ldf', " +
           "SIZE = 1MB, " +
           "MAXSIZE = 5MB, " +
           "FILEGROWTH = 10%)";
      SqlCommand myCommand = new SqlCommand(str, myConn);
      try 
      {
        myConn.Open();
        myCommand.ExecuteNonQuery();
       }
      catch (System.Exception ex)
      {
        Console.Write(ex.ToString());
      }
      finally
      {
        if (myConn.State == ConnectionState.Open)
        {
        myConn.Close();
        }
      }
