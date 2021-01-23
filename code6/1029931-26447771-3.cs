    using (OleDbDataReader reader = command.ExecuteReader())
    {
        while (reader.Read())
        {
            Integer.TryParse(reader[0].ToString(), _count);
            if (_count > 0)
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
