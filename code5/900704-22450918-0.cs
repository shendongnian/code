    DateTime dt1= DateTime.ParseExact("Yourdate1","yyyy-MM-dd",
                                                  CultureInfo.InvariantCulture);
    DateTime dt2= DateTime.ParseExact("Yourdate2","yyyy-MM-dd",
                                                  CultureInfo.InvariantCulture);
    
    int result = DateTime.Compare(dt1,dt2) ;
    if(result == 0)
    {
     //both dates are same    
    }
    else if(result < 0)
    {
     //Date1 is lessthan Date2
    }
    else 
    {
    //Date2 is lessthan Date1
    }
