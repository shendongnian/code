    public bool Login(LoginClass loginClassObj)
    {
        string connectionString = ...
        using(SqlConnection connection = new SqlConnection(connectionString))
        using(SqlCommand command = connection.CreateCommand())
        {
            connection.Open();
            command.CommandText = @"SELECT COUNT(log_in) FROM login_table
                                    WHERE username = @username AND hash = @hash";
            command.Parameters.AddWithValue("username", loginClassObj.Username);
            command.Parameters.AddWithValue("hash", loginClassObj.GetSecureHash());
            int count = Convert.ToInt32(command.ExecuteScalar());
            return count == 1;
        }
    }
