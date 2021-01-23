    using(var connection = new SqlConnection("*****"))
    using(var cmd = connection.CreateCommand())
    {
        cmd.CommandText = "SELECT IMAGE,NAME_IMAGE,CODE FROM IMAGES";
        connection.Open();
        using(var reader = cmd.ExecuteReader())
        {
            while(reader.Read())
            {
                byte[] data = (byte[])reader["IMAGE"];
                string name = (string)reader["NAME"];
                // ...
            }
        }
    }
