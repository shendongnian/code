    public bool DatabaseExists(string dbname)
    {
    string connStr = "server=localhost;database=INFORMATION_SCHEMA;";
    
    using (MySqlConnection myConnection = new MySqlConnection(connStr))
    {
	 string sql = "show databases";
	 MySqlCommand myCommand = new MySqlCommand(sql, myConnection);
	 myConnection.Open();
	 MySqlDataReader myReader = myCommand.ExecuteReader();
	 while (myReader.Read())
     {
	   string db =	myReader["Database"].ToString();
	   if (db == dbname)
         return true;
	 }
    }
    return false;
    }
