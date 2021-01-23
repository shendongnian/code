    string connectionString = ConfigurationManager.AppSettings["MyDatabase"];
    var conn = new SqlConnection(connectionString);
    conn.Open();
    string query = @"my_stored_procedure";
    using (var sqlAdpt = new SqlDataAdapter(query, conn))
    {
        sqlAdpt.SelectCommand.CommandType = CommandType.StoredProcedure;
        // Ex: Parameters if your sp takes one
        var dataDate = new SqlParameter { ParameterName = "@DataDate", Value = DateTime.Now };
        sqlAdpt.SelectCommand.Parameters.Add(dataDate);
        var results = new DataSet();
        sqlAdpt.Fill(results);
        List<Result> resultList = results.Tables[0].AsEnumerable().
            Select(dataRow => new Result
            {
                myID = dataRow.Field<int>("ID"),
                myString = dataRow.Field<string>("column_I_cant_change")
            }).ToList();
    
    }
