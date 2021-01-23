    string[] formats = { "yyyy-MM-dd", "yyyy/MM/dd" };
    DateTime date;
    if (DateTime.TryParseExact(input, formats,
                               CultureInfo.InvariantCulture,
                               DateTimeStyles.None, out date))
    {
        // Add date to the DataTable
    }
    else
    {
        // Handle parse failure. If this really shouldn't happen,
        // use DateTime.ParseExact instead
    }
