    private string connectionString = "...";
    using(var con = new OleDbConnection(connectionString)) {
        con.Open();
        using(var cmd = con.CreateCommand()) {
            cmd.CommandText = @"
                insert into [pending] ( [val1], [val2], [val3], [val4], [val5], [date] )
                values ( ?, ?, ?, ?, ?, ? )";
                
            // Parameter names are just to clarify what we're doing
            cmd.Parameters.AddWithValue("val1", v1);
            cmd.Parameters.AddWithValue("val2", v2);
            cmd.Parameters.AddWithValue("val3", v3);
            cmd.Parameters.AddWithValue("val4", v4);
            cmd.Parameters.AddWithValue("val5", v5);
            cmd.Parameters.AddWithValue("date", DateTime.Now);
            cmd.ExecuteNonQuery();
        }
        con.Close();
    }
