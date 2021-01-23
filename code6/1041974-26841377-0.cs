    var input = "2014-07-23 06:00";
    var inputFormat = "yyyy-MM-dd HH:mm";    
    var outputFormat = "yyyy-MM-dd-HH.mm.ss.ffffff";
    DateTime dateTime;
    if (DateTime.TryParseExact(
            input, 
            inputFormat, 
            null, 
            System.Globalization.DateTimeStyles.None, 
            out dateTime))
    {
        Console.Write(dateTime.ToString(outputFormat));
    }
    else
    {
        Console.Write("Could not parse");
    }
