    using (SqlConnection con = new SqlConnection(ConnectionString)) {
        con.Open();
        using (SqlCommand command = new SqlCommand("ProcedureName", con)) {
            command.CommandType = CommandType.StoredProcedure;
            using(SqlReader reader = command.ExecuteReader()){
                if (reader.HasRows) {
                     while(reader.Read()) {
                         ... process SqlReader objects...
                     }
                }
            }
        }
    }
