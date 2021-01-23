	[HttpPost]
    public ActionResult BookFlight(BookingModel booking)
    {
		if(ModelState.IsValid)
		{
			// valid
		}
		return View(booking);
	}
