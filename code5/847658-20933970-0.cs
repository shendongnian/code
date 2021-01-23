    public DataSet GetRelations()
    {
        using (var connection = new OleDbConnection(ConnectionString))
        {
            connection.Open();
            using (var adapter = new OleDbDataAdapter("SELECT * FROM [relation]", connection))
            {
                var results = new DataSet();
                adapter.Fill(results);
                return results;
            }
        }
    }
    public DataSet GetTimeResults()
    {
        DataSet dsRelations = GetRelations();
        var dsResults = new DataSet();
        using (var connection = new OleDbConnection(ConnectionString)) 
        {
            connection.Open();
            foreach (DataRow row in dsRelations.Tables[0].Rows)
            {
                using (var command = new OleDbCommand("SELECT * FROM [time] Where classid = ?", connection))
                {
                    // not entirey sure what the value of row.ItemArray[2] is ?
                    command.Parameters.Add(row.ItemArray[2]);
                    using (var adapter = new OleDbDataAdapter(command))
                    {
                        adapter.Fill(dsResults);
                    }
                }
            }
        }
        return dsResults;
    }
