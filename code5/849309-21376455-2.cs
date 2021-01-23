    using (var sqlConnection = new SqlConnection("connstring"))
     {
        sqlConnection.Open();
        using (var sqlCommand = new SqlCommand
           {
              Connection = sqlConnection,
              CommandText = "dbo.MyProc",
              CommandType = CommandType.StoredProcedure,
           })
        {
           // Once-off setup per connection
           // This parameter doesn't vary so is set just once
           sqlCommand.Parameters.Add("ConstantParam0", SqlDbType.Int).Value = 1234;
           // These parameters are defined once but set multiple times
           sqlCommand.Parameters.Add(new SqlParameter("VarParam1", SqlDbType.VarChar));
           sqlCommand.Parameters.Add(new SqlParameter("VarParam2", SqlDbType.DateTime));
           // Tight loop - performance critical
           foreach(var item in itemsToExec)
           {
             // No need to set ConstantParam0
             // Reuses variable parameters, by just mutating values
             sqlParameters["VarParam1"].Value = item.Param1Value; // Or sqlParameters[1].Value
             sqlParameters["VarParam2"].Value = item.Param2Date; // Or sqlParameters[2].Value
             sqlCommand.ExecuteNonQuery();
           }
        }
    }
