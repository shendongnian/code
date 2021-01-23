    public ActionResult BookFlight()
    {
        using (var context = new FlightsDBEntities())
        {
            // Get all of the flights within your table
            var flights = context.FlightsTables.ToList();
			var booking = new BookingModel();
			booking.Flights = flights.Select(f = new SelectListItem
												{
													Text = String.Format("{0} to {1}", f.Departure, f.Arrival),
													Value = f.FlightID
												}).ToList();
            // Pass the flights to your View
            return View(booking);
        }
    }
	
