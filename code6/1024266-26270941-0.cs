    public sqliteConnection GetConnection()
    {
    var con= new sqliteconnection(connectionString);
     try
     {
    	con.Open();
     }
     catch (Exception ex)
     {
     }
    return con;
    }
