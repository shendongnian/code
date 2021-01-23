    using (SqlConnection connection = new SqlConnection(strConnectionString))
    {
        connection.Open();
        DataTable schema = connection.GetSchema("Tables");
        List<string> TableNames = new List<string>();
        foreach (DataRow row in schema.Rows)
        {
            TableNames.Add(row[2].ToString());
        }
        
        if(TableNames.Count == 0) MessageBox.Show("No table exists in the database.");
    }
