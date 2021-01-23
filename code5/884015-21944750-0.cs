    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
    	connection.Open();
    	using (SqlCommand cmd = new SqlCommand("UPDATE easy SET words='blahblahblah' WHERE id=1;", connection))
    	{
    		cmd.ExecuteNonQuery();
    	}
    }
