    DateTime dt;
    if (!DateTime.TryParse(stringValue, out dt)
    {
        if (!DateTime.TryParse(stringValue, new CultureInfo("en-US").DateTimeFormat, DateTimeStyles.None, out dt)
            throw new ArgumentException("Unable to parse date");
    }
    // If you reach this line, you were able to parse the DateTime.
