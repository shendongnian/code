    // Other code as before
    while (reader.Read())
    {
        DateTime date = DateTime.ParseExact(reader.GetDateTime(0),
                                            "yyyy-MM-dd", // Or whatever the format is
                                            CultureInfo.InvariantCulture);
        if (today > date)
        {
            // Do something
        }
    }
