    int imins = 31;    
    TimeSpan ts = TimeSpan.FromMinutes(imins);	
    string sHours = ts.Hours.ToString();
	
    if (sHours.Length == 1)
      sHours = "0" + sHours;
	
    string sMinutes = ts.Minutes.ToString();
	
    if (sMinutes.Length == 1)
      sMinutes = "0" + sMinutes;
    Console.WriteLine(sHours + ":" + sMinutes);
	Console.Read();
