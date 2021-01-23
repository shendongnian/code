    private bool CheckCredentials()
    {
        bool result = false;
        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand("checkuser", conn))
        {
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@userid", username.Text);
            cmd.Parameters.Add("@password", username.Text);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    result = reader.GetBoolean(0);
                }
            }
        }
        return result;
    }
