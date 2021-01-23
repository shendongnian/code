    public string GetVersion()
    {
        using (var connection = new SqlCeConnection("my connection string"))
        {
            connection.Open();
            using (var command = new SqlCeCommand("SELECT id FROM invHeader", connection))
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return reader.GetString(0);
                }
                else
                {
                    // no result
                    return null;
                }
            }
        }
    }
