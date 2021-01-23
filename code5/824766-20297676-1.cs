      using (var conn = new SqlConnection(SomeConnectionString))
        using (var cmd = conn.CreateCommand())
        {
            conn.Open();
            cmd.CommandText = "SELECT RemainedCharge "
                                      + " FROM aspnet_Users "
                                      + " WHERE UserName = @UserName ";
            cmd.Parameters.Add(new SqlParameter("@UserName", username);
            cmd.Parameters.AddWithValue("@id", index);
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    learerLabel.Text = reader.GetString(reader.GetOrdinal("somecolumn"))
                }
            }
    
    }
