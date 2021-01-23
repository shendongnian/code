	[HttpPost]
    public ActionResult BookFlight(BookingModel booking)
    {
        using (var context = new FlightsDBEntities())
        {
		    if(ModelState.IsValid)
	    	{
		    	var flight = context.FlightsTables.First(f => f.FlightID == Int32.Parse(booking.SelectedFlightId));
                // make something with flight
		    }
            // repopulate again the flights (this can be cached and/or be refactored a under method)
            var flights = context.FlightsTables.ToList();
	        booking.Flights = flights.Select(f => new SelectListItem
								{
									Text = String.Format("{0} to {1}", f.Departure, f.Arrival),
									Value = f.FlightID.ToString()
								}).ToList();
	    }
     	return View(booking);
	}
