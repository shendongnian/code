    using (SqlCeConnection conn = new SqlCeConnection(connStr))
    {
        conn.Open();    
        SqlCeCommand cmd = new SqlCeCommand(@"SELECT TOP 1 * 
                                              FROM INFORMATION_SCHEMA.TABLES 
                                              WHERE TABLE_NAME = @tname", conn);
        cmd.Parameters.AddWithValue("@tname", tableName)
        SqlCeDataReader reader = cmd.ExecuteReader();
        if(reader.Read())
            Console.WriteLine("Table exists");
        else
            Console.WriteLine("Table doesn't exist");
 
    }
