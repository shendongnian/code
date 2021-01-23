    using (var conn = new SqlConnection(connectionString))
    using (var command = new SqlCommand("ProcedureName", conn) { 
                               CommandType = CommandType.StoredProcedure }) {
       conn.Open();
       command.ExecuteNonQuery();
       conn.Close();
    }
