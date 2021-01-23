    DBCon  = DBConnection.Instance();
    DBCon.DatabaseName = "YourDatabase";
    if(DBCon.IsConnect())
    {
       string query = "Select * from YourTable";
       MySqlComman cmd = new MySqlComman(query,DBCon.GetConnection());
       MySqlDataReader dr = cmd.ExecuteReader();
    
    }
