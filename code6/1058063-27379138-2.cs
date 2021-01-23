    string[] allowedFormats = { "dd/M/yyyy hh:mm:ss tt", "ddd dd MMM yyyy" };
    DateTime dt;
    if (DateTime.TryParseExact(strDate1, allowedFormats, System.Globalization.DateTimeFormatInfo.InvariantInfo, System.Globalization.DateTimeStyles.None, out dt))
    {
        Console.WriteLine("strDate1 parsed successfully: " + dt); 
    }
    if (DateTime.TryParseExact(strDate2, allowedFormats, System.Globalization.DateTimeFormatInfo.InvariantInfo, System.Globalization.DateTimeStyles.None, out dt))
    {
        Console.WriteLine("strDate2 parsed successfully: " + dt);
    }
