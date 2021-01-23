        using(MySqlConnection conn = new MySqlConnection(connStr))
    {
       conn.Open();
       using(MySqlCommand command  = new MySqlCommand("command to execute",conn))
    {
       //Code here..
    }
    
    }
