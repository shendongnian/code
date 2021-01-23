    var cmd = new SqlCommand(query);
    var reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        list.Add(new
        {
            CatName = reader.GetString(0),
            CatDOB = reader.GetDateTime(1),
            CatStatus = reader.GetInt32(2),
        });
    }
