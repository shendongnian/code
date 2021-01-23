    MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
    conn_string.Server = "mysql14.000webhost.com";
    conn_string.UserID = "a7709578_codecal";
    conn_string.Password = "xxxxxxx";
    conn_string.Database = "a7709578_codecal";
    
    using (MySqlConnection conn = new MySqlConnection(conn_string.ToString()))
