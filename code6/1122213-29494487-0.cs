    protected void Session_Start()  
    {  
          var count = (int)Application["Totaluser"] + 1;
          Application.Lock();
          ExecuteQueryToUpdateCountInDatabase();
          Application["Totaluser"] = count;  
          Application.UnLock();  
    }   
