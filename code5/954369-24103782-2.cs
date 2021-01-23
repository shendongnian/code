    private byte[] GetThumbData(int userId) {
        using (var conn = new SqlConnection("YOUR CONNECTION STRING ..."))
        using (var cmd = new SqlCommand("SELECT THUMB FROM VOTER WHERE ID = @ID", conn)) {
            conn.Open();
            cmd.Parameters.AddWithValue("@ID", userId);
            return cmd.ExecuteScalar() as byte[];
        }
    }
