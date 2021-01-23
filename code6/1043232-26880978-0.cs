    private SqlConnection con ;
    public bool ConnectDB()
    {
      con= new SqlConnection();
      con.ConnectionString= your_copied_string;
      if (con.State == ConnectionState.Closed)//always true
      {
         con.Open();
         return true;
    
      }
    }
        
    
