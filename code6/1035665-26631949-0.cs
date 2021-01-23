    SQLiteDataReader reader = db.CreateCommand("Select namebd from names").ExecuteReader();
    List<string> list = new List<int>();
    using (SqlDataReader reader = reader){
        while (reader.Read())
        {
             list.Add(reader.GetString(0));
        }    
    }
    return list.ToArray();
