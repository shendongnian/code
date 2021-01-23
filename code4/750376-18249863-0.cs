      public List<T> CreateList<T>(T itemOftype)
      {
         List<T> newList = new List<T>();
         return newList;
      } 
    
       var error = new { Header= "AVBC", Details = "Details" };
       var errorList = CreateList(error );
    
       errorList.Add(new { Header= "AVBC_BCGBD", Details = "Details_SBNJHJH" }
