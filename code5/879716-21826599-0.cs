    bool CheckConnectionStatus()
    {
      try
      {
        String strConnection="/*your connection string here*/";
        SqlConnection con = new SqlConnection(strConnection);
        con.Open();
      }
      catch(Exception e)
      {
        return false;
      }
    
        return true;
    }
