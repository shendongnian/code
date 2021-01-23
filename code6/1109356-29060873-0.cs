    public void Execute(string sql, Action<IDataRecord> action)
    {
        using(var connection = new ...)
        {
            connection.Open();
    
            using(var command = new ...)
            {
                using(var reader = command.ExecuteReader())
                {
                   while(reader.Read())
                   {
                       action(reader);
                   }
                }
            }
        }
    }
