    public void Update()
    {
         //Update Magic
         try 
         {
            changeLog.LogUpdateCustomer();
         } 
         catch(Exception ex)
         {
             rollbackLog.Rollback();
         }    
    }
