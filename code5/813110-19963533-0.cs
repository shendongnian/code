    string query = "SELECT * FROM teams ORDER BY name";
    using(MySqlConnection dbConn = new MySqlConnection(conn))
    {
        MySqlCommand cmd = new MySqlCommand(query, dbConn);
        dbConn.Open();//here **
        MySqlDataReader dataReader = cmd.ExecuteReader();
