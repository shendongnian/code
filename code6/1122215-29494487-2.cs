    protected void Session_Start()  
    {  
          var serviceLayer = new Services();
          var count = (int)Application["Totaluser"] + 1;
          Application.Lock();
          serviceLayer.ExecuteQueryToUpdateCountInDatabase(count);
          Application["Totaluser"] = count;  
          Application.UnLock();  
    }   
