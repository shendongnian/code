    using(var command = new OleDbCommand(query, connection))
    {
        command.Parameters.AddWithValue("@ProductId", id);
    
        using(var reader = command.ExecuteReader())
        {
            if(reader.Read())
            {
                var sr = Convert.ToInt32(reader[0]);
                var pr = Convert.ToInt32(reader[1]);
                var difference = Convert.ToInt32(reader[2]);
            }
        }
    }
