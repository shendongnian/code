    public string GetMatchCode()
    {
        //this could be loaded from config file or other source
        string connectString = "Server=myServer;Database=myDB;Uid=myUser;Pwd=myPass;";
        string sql = "SELECT MAX(VAL(match_id)) FROM `data`";
        using (var connect = new MySqlConnection(connectString))
        using (var command = new MySqlCommand(sql, connect))
        {
            connect.Open();
            return command.ExecuteScalar().ToString();
        }
    }
