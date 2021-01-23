    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Booking booking)
    {
        if (ModelState.IsValid)
        {
            db.Bookings.Add(booking);
            db.SaveChanges();
    
            return RedirectToAction("Details", new { bookingId = booking.Id });
        }
    
        return View(booking);
    }
    
    public ActionResult Details(int bookingId)
    {
        var details = GetBookingDetails(bookingId); //Load details
        return View(details);
    }
