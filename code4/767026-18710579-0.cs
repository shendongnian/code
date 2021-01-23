     public void getData()
     {
       try
       {
           using(var conection=oConn.GetConnection)
           {
                 //execute your query
           }
          
        }
        catch
        {
              //do something to show user an error or just log it
        }
        finally
        {
             //you do not have to close connection because using statement will do this for you
        }
     }
