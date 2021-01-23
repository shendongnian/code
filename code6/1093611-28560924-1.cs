    DateTime start, end;
    if (!DateTime.TryParseExact(startTextBox.Text, "yyyy-MM-dd",
                                CultureInfo.InvariantCulture, DateTimeStyles.None,
                                out start))
    {
        // Invalid start - handle appropriately.
    }
    if (!DateTime.TryParseExact(endTextBox.Text, "yyyy-MM-dd",
                                CultureInfo.InvariantCulture, DateTimeStyles.None,
                                out end))
    {
        // Invalid end - handle appropriately.
    }
    var diff = end - start;
