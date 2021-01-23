    string dateText = match.Value;
    DateTime date;
    if (DateTime.TryParseExact(dateText, "dd/MM/yyyy",
                               CultureInfo.InvariantCulture,
                               DateTimeStyles.None, out date))
    {
        // Use date
    }
    else
    {
        // Couldn't parse the value
    }
