    // declare/open the connection (depends on the current application design
    
    string sql = "SELECT * FROM Emoticons
    // cmd.ExecuteReader above query to get dataReader (dr)
    
    while(dr.Read())
    {
        string key = dr.GetString(dr.GetOrdinal("Emoticons"));
    
        if(!emoticons.ContainsKey(key))
            emoticons.Add(key, dr.GetString(dr.GetOrdinal("convert_test"));
    }
    dr.Close();
