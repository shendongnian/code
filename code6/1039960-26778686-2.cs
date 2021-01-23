    using (SqlConnection con = new SqlConnection(Properties.Settings.Default.connectionstring2)) {
        con.Open();
    
        SqlCommand cmd  = new SqlCommand("GetData", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@colName", columns));
        cmd.Parameters.Add(new SqlParameter("@tableName", selectedTable));
    
        using (SqlDataReader rdr = cmd.ExecuteReader()) {
    
            while (rdr.Read())
            {
                // do what ever you want with your records.
            }
        }
    }
