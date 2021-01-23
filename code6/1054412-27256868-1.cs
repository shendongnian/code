        try 
        {
          string Connectioncacha = "";
        
          CacheConnection CacheConnect = new CacheConnection();
          CacheConnect.ConnectionString = Connectioncacha;
          CacheConnect.Open();
        
        } 
        catch (Exception e)
        {
         
           if (CacheConnect)
               CacheConnect.Close();
        }
