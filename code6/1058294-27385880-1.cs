    var tableNames = new List<string>();
    var con = new SqlConnection(
                  ConfigurationManager.ConnectionStrings["DBBASE"].ConnectionString);
                    
    using (var cmd = new SqlCommand("GetTableNames", con)
            {
                CommandType = CommandType.StoredProcedure
            })
    {                 
        cmd.Parameters.Add("@schema", "TMP");    
        con.Open();
        using (var reader = cmd.ExecuteReader())
        {
            while(reader.MoveNext())
            {
                tableNames.Add(reader.GetString(0))
            }
        }
    }
    var result = string.Join(
        Environment.NewLine,
        tableNames
            .Select(tn => string.Format("DROP TABLE [TMP].[{0}];", tn))
            .ToArray());
