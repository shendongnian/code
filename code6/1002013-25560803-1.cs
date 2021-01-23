    public int GetMatchCode()
    {
        //this could be loaded from config file or other source
        string connectString = "Server=myServer;Database=myDB;Uid=myUser;Pwd=myPass;";
        string sql = "SELECT MAX(VAL(match_id)) FROM `data`";
        using (var connect = new MySqlConnection(connectString))
        using (var command = new MySqlCommand(sql, connect))
        {
            connect.Open();
            var result = command.ExecuteScalar();
            if (result == DBNull.Value)
            {              
               //what you do here depends on your application
               // if it's impossible for the query to return NULL, you can even skip this
            }
            return (int)result;
        }
    }
