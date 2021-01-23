    DateTime datDate;
    if(DateTime.TryParseExact(strDate , new string[] { "dd/MM/yyyy" },
                           System.Globalization.CultureInfo.InvariantCulture,
                           System.Globalization.DateTimeStyles.None, out datDate))
    
    {
       // Call your update method with 
    }
    else
    {
     //Show validation error message
    }
    
