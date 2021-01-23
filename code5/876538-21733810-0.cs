    using (var reader_user = cmd.ExecuteReader())
    {
        while (reader_user.Read())
        {
            MapUser(reader_user);
        }
       
        reader_user.NextResult();
    
        while (reader_user.Read())
        {
            Whatever(reader_user);
        }
    }
