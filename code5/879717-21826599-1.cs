    bool CheckConnectionStatus()
    {
        String strConnection="/*your connection string here*/";
        SqlConnection con = new SqlConnection(strConnection);
        if(con.State == ConnectionState.Closed)
        {
           try
          {        
           con.Open();
          }
           catch(Exception e)
          {
            return false;
          }
        }
        else
       {
        return true;
       }
    }
