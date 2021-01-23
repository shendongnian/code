       try
       {
         //code 
       }
       catch (WebException ex)
       {
           if (ex.Status == WebExceptionStatus.Timeout)
           {
               //log your exception
           }
       }
