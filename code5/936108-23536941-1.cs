    string strDate = "16-Aug-78 12:00:00 AM";           
    DateTime datDate;
    if(DateTime.TryParseExact(strDate , new string[] {"dd-MMM-yy hh:mm:ss tt" },
                           System.Globalization.CultureInfo.InvariantCulture,
                           System.Globalization.DateTimeStyles.None, out datDate))
     {
       Console.WriteLine(datDate);
     }
    
     else
     {
       Console.WriteLine("Error in datetime format");
     }
