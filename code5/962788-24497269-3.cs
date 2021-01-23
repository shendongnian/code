    DateTime dt;
    if (!DateTime.TryParseExact("07:35", "HH:mm", CultureInfo.InvariantCulture, 
                                                  DateTimeStyles.None, out dt))
    {
        // handle validation error
    }
    TimeSpan time = dt.TimeOfDay;
