    string columns = string.Join("," 
        , dataTable.Columns.Cast<DataColumn>().Select(c => c.ColumnName));
    string values = string.Join("," 
        , dataTable.Columns.Cast<DataColumn>().Select(c => string.Format("@{0}", c.ColumnName)));
    String sqlCommandInsert = string.Format("INSERT INTO dbo.RAW_DATA({0}) VALUES ({1})" , columns, values);
    
    using(var con = new SqlConnection("ConnectionString"))
    using (var cmd = new SqlCommand(sqlCommandInsert, con))
    {
        con.Open();
        foreach (DataRow row in dataTable.Rows)
        {
            cmd.Parameters.Clear();
            foreach (DataColumn col in dataTable.Columns)
                cmd.Parameters.AddWithValue("@" + col.ColumnName, row[col]);
            int inserted = cmd.ExecuteNonQuery();
        }
    }
