    public List<MemoryObject> GetMemoryObjects()
    {
        using (SqlConnection connection = new SqlConnection("..."))
        {
            string sql = "query";
    
            SqlCommand command = new SqlCommand(sql.ToString(), connection);
            command.CommandTimeout = 3600;
    
            connection.Open();
            var memoryObjects = new List<MemoryObject>();
    
            using (var rdr = command.ExecuteReader())
                {
                        while (rdr.Read())
                        {
                            var memoryObject = new MemoryObject {
                                Id = rdr.GetInt64(0),
                                OtherProperty = rdr.GetString(1)
                            };
                            memoryObjects.Add(memoryObject);
                        }                   
                }
        }
    
        return memoryObjects;
    }
