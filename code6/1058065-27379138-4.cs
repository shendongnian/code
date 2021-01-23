    string strDate1 = "12/2/2014 12:00:00 AM";
    string strDate2 = "Mon 12 Sep 2014";  // it was a friday ;)
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
