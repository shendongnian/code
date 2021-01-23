    string valueFromCsv = "9/8/2011";
    DateTime result;
    
    if (DateTime.TryParseExact(valueFromCsv, "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
    {
        // Success
    }
    else
    {
        // Invalid value
    }
