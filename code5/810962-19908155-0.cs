    DateTime parsedDate;
    if (DateTime.TryParseExact("11 11 2013", "MM dd yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out parsedDate))
    { 
        // parsed successfully, parsedDate is initialized
        string result = parsedDate.ToString("MM dd yyyy", System.Globalization.CultureInfo.InvariantCulture);
        Console.Write(result);
    }
