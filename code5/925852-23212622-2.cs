    string s = "26/1/2014 02:17 PM";
    DateTime dt;
    if(DateTime.TryParseExact(s, "dd/M/yyyy hh:mm tt", 
                              CultureInfo.GetCultureInfo("en-US"), 
                              DateTimeStyles.None, out dt))
    {
       Console.WriteLine(dt);
    }
    else
    {
       //Your string is not a valid DateTime.
    }
