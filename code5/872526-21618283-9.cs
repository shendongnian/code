    var dbCon = DBConnection.Instance();
    dbCon.DatabaseName = "YourDatabase";
    if (dbCon.IsConnect())
    {
        string query = "SELECT * FROM YourTable";
        var cmd = new MySqlCommand(query, dbCon.Connection);
        var reader = cmd.ExecuteReader();
    }
