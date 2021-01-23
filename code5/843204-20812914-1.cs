    public string CheckReminder(Object oDueDate)
    {
     DateTime DueDate=Convert.ToDateTime(oDueDate);
     if(DueDate>=DateTime.Now.Date)
     {
      return "inline";
     }
    }
    public string CheckReminder2(Object oDueDate)
    {
     DateTime DueDate=Convert.ToDateTime(oDueDate);
     if(DueDate>=DateTime.Now.Date)
     {
      return "none";
     }
    }
