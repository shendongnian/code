    public ActionResult SearchResult(string searchDate)
    {
        var bookings = from m in db.Bookings
                       select m;
        if (!String.IsNullOrEmpty(searchDate))
        {
            bookings = bookings.Where(s => s.Date1.CompareTo( DateTime.ParseExact(searchDate, "dd-mm-yyyy", CultureInfo.InvariantCulture) >= 0);
        }
        return View(bookings);
    }
