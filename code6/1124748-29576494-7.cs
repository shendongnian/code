	[HttpPost]
    public ActionResult BookFlight(BookingModel booking)
    {
		if(ModelState.IsValid)
		{
			// booking.SelectedFlightId
		}
		return View(booking);
	}
