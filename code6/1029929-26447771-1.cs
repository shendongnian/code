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
