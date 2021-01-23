    string dateString = "20130916";
    DateTime parsedDateTime;
    string formattedDate;
    if(DateTime.TryParseExact(dateString, "yyyyMMdd", 
                        CultureInfo.InvariantCulture, 
                        DateTimeStyles.None, 
                        out parsedDateTime))
    {
        formattedDate = parsedDateTime.ToString("MM/dd/yyyy");
    }
    else
    {
           Console.WriteLine("Parsing failed");
    }
