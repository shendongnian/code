    OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\David\Desktop\Dbase_Files;Extended Properties=dBASE IV;User ID=Admin;Password=");
    
    connection.Open();
    
    OleDbTransaction trans = connection.BeginTransaction();
    OleDbCommand command = new OleDbCommand(@"INSERT INTO [tablename.DBF] 
                                            VALUES
                                            (
                                            @param1, @param2, @param3
                                            );", connection, trans);
    
    command.Parameters.AddWithValue("param1", 7);
    command.Parameters.AddWithValue("param2", "RCN");
    command.Parameters.AddWithValue("param3", 0);
    
    try
    {
        command.ExecuteNonQuery();
        trans.Commit();
    }
    catch (Exception e)
    {
        trans.Rollback();
        throw e;
    }
    finally
    {
        connection.Close();
    }
