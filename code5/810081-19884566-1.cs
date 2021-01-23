    var value = "2013/11/07 23:08:53 +0000";
    DateTime dateTime;
    
    if(DateTime.TryParse(value, out dateTime))
    {
        // The string is a valid DateTime
        // This will output '11:08 PM'
        Console.WriteLine(dateTime.ToShortTimeString());
    }
    else
    {
        // The string is not a valid DateTime
    }
