    string query = "SELECT * FROM [Member] WHERE [UserType] = @UserType";
    connection.Open();
    using (OleDbCommand command = new OleDbCommand(query, connection))
    {
        command.Parameters.Add("@UserType", OleDbType.VarChar);
        command.Parameters["@UserType"].Value = _value1;
        using (OleDbDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    _isUsed = true;
                }
    
                else
                {
                    _isUsed = false;
                }
        }
        reader.Close();
    }
