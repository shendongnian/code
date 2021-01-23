    public string DateTimeToMsDate( DateTime dt )
    {
       return ((int) (dt-epoch).TotalDays ).ToString() ;
    }
      
