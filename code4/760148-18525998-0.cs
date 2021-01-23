    using (var conn = new SqlConnection(connectionString))
    using (var command = new SqlCommand("CreateNewMember", conn) { 
                               CommandType = CommandType.StoredProcedure }) {
       command.Parameters.AddWithValue("@na", Mem_NA);
       command.Parameters.AddWithValue("@occ", Mem_Occ);
       command.Parameters.AddWithValue("@role","Member");
       conn.Open();
       command.ExecuteNonQuery();
       conn.Close();
    }
