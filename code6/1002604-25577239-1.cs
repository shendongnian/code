    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
    {
        using (var cmd = new SqlCommand("AddStuffIfCityExists", conn))
        {
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@city", "Berlin"));
            cmd.ExecuteNonQuery();
        }
    }
