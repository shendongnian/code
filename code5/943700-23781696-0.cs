    DateTime newDate = null;
    try 
    {
        var obj = startsUps.FirstOrDefault();
        newDate = obj.DATE_TIME ?? DateTime.Now;
    }
    catch 
    {
        //If FirstOrDefault() is null do something else
        newDate = DateTime.Now;
    }
