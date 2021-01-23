     //conn.Open();
    
            try
            {
              conn.Open();
              //Your Code
              
            }
            finally
            {
               conn.Close();   
               conn.Dispose();//Do not call this if you want to reuse the connection
            }
