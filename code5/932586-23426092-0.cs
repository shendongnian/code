    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        SqlCommand cmd = new SqlCommand("dbo.usp_temp", connection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 90;
        
        // Map the parameters into the Stored Procedure
        SqlParameter param = cmd.Parameters.Add("@latitude", SqlDbType.Decimal);
        param.Direction = ParameterDirection.Input;
        param.Value = latitude;
        
        try
        {
            rowsAffected = cmd.ExecuteNonQuery();
        }
        catch (Exception ep)
        {
            Console.WriteLine("Exception in Insertrecords ");
            Console.WriteLine(ep.Message);
        }
    }
