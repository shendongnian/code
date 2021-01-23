    using(var connection= new SqlConnection(connectionString))
    {
        connection.Open();
        var sql = @"SELECT password, salt FROM users WHERE userid = @userid";
        var command = new SqlCommand(sql, connection);
        command.Parameters.Add("@userid", SqlDbType.VarChar);
        command.Parameters["@userid"].Value = username;
        using(var reader = command.ExecuteReader())
        {
            if (!reader.HasRows) 
            { 
                Debug.WriteLine("The user {0} does not exist", username);
                return false;
            }
            if (reader.Read())
            {
                var password = reader.GetString(0);
                var salt = reader.GetString(1);
                return CheckPassword(password, salt, PwrdTextBox.Text);
            }
            return false;
        }
    }
