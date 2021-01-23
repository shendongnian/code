    var dbCon = DBConnection.Instance();
    dbCon.DatabaseName = "YourDatabase";
    if(dbCon.IsConnect())
    {
       string query = "SELECT * FROM YourTable";
       MySqlCommand cmd = new MySqlCommand(query, dbCon.GetConnection());
       MySqlDataReader dr = cmd.ExecuteReader();
    }
