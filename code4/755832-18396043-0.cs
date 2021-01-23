    DateTime parsed = DateTime.ParseExact(endTime.Trim(), "hh:mm tt",
                                          CultureInfo.InvariantCulture);
    // If you need a string
    client.EndTime = parsed.ToString("HH:mm:ss", CultureInfo.InvariantCulture);
    // If you just need a TimeSpan
    client.EndTime = parsed.TimeOfDay;
