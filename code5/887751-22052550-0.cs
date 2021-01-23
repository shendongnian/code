    CreateUser()
    {
        using(SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStringDb1"].ConnectionString))
        {
            conn.Open();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "tsql to create users here";
                cmd.ExecuteNonQuery();
            }
        }
        
    }
