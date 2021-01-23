    using MySql.Data.MySqlClient;
    
    using(MySqlConnection myConnection = new MySqlConnection(myConnectionString))
    {
        myConnection.Open();
        // execute queries, etc
    }
