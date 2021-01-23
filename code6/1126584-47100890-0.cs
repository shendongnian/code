    try
    {
        connection.Open();
        cmd = new SqlCommand();
        
        transaction = connection.BeginTransaction();
        cmd.Transaction = transaction;
        cmd.Connection = connection;
        cmd.CommandText = "InsertMsg";
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter ID = cmd.Parameters.Add("@ID", SqlDbType.VarChar);
        SqlParameter name = cmd.Parameters.Add("@name", SqlDbType.VarChar);
        SqlParameter age = cmd.Parameters.Add("@age", SqlDbType.DateTime);
        for (int i = 0; i < number; i++)
        {
            ID.Value = IDs[i];
            name.Value = names[i];
            age.Value = age;
            cmd.ExecuteNonQuery();
            data[i] = IDs[i]; 
        }
        transaction.Commit();
    }
    catch (SqlException ex)
    {
        transaction.Rollback();
        data[0] = "Error";
    }
    finally
    {
        connection.Close();
    }
    return data;
