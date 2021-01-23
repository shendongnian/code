    if (!String.IsNullOrEmpty(searchDate))
    {
        DateTime dt = DateTime.ParseExact(searchDate, "dd-mm-yyyy", CultureInfo.InvariantCulture);
        bookings = bookings.Where(s => s.Date1 >= dt);
    }
