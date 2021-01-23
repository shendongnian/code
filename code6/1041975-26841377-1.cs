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
        Console.Write(
            "{0} converts to {1}", 
            inputFormat, 
            dateTime.ToString(outputFormat));
    }
    else
    {
        Console.Write("{0} is not the correct format", inputFormat);
    }
