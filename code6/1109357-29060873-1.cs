    public IEnumerable<IDataRecord> Execute(string sql)
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
                       yield return reader;
                   }
                }
            }
        }
    }
