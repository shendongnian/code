    string str = @"server=localhost;database=test;userid=root;password=asd;";
    string query = "SELECT * FROM emp";
    
    MySqlConnection con = new MySqlConnection(str);
    con.Open(); 
    
    
    MySqlCommand cmd = new MySqlCommand(query, con);
    
    cmd.CommandText = query;
    MySqlDataReader reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        for (int i = 0; i < reader.FieldCount; i++)
        {
            var value = reader[i];
            arrList.Add(Convert.ToString(value))
        }
    }
