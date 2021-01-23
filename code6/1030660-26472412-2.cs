    static string connStr = "server=localhost;user=root;port=3306;password=*******;";
    public static MySqlConnection Connect()
    {        
        MySqlConnection conn = new MySqlConnection(connStr);   
        conn.Open();            
        return conn;
    }
