    string insertSql = "INSERT INTO animalType (type) VALUES (@type)";
    var types = new[] { 1, 2, 3 };
    using(SqlCommand command = new SqlCommand(insertSql, conn))
    {
        foreach(var type in types)
        {
            command.Parameters.AddWithValue("@type", type);
            command.ExecuteNonQuery();
        }
    
    }
