    using (var sqlConnection = new SqlConnection("connstring"))
     {
        sqlConnection.Open();
        var sqlParameters = new SqlParameter[] 
        {
           new SqlParameter("PARAM1", SqlDbType.VarChar),
           new SqlParameter("PARAM2", SqlDbType.DateTime),
        };
        using (var sqlCommand = new SqlCommand
           {
              Connection = sqlConnection,
              CommandText = "dbo.MyProc",
              CommandType = CommandType.StoredProcedure,
           })
        {
           sqlCommand.Parameters.AddRange(sqlParameters);
           // Tight loop
           foreach(var item in itemsToExec)
           {
             // Mutate and reuse
             sqlParameters[0] = item.Param1Value;
             sqlParameters[1] = item.Param2Date;
             sqlCommand.ExecuteNonQuery();
           }
        }
    }
