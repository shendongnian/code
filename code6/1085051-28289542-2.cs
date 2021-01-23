    public ActionResult RequestDetails(int id)
    {
      var model = SystemDB.Events
        .Where(e => e.BookingId == id)
        .OrderByDescending(e => e.EventId)
        .Select(e => new RequestDetailsViewModel()
        {
          Event.EventId = e.EventId,
          Event.EventLeader = e.EventLeader,
          ...
          Event.Booking.BookingId = e.BookingId;
          Event.Booking.StatusCodeId = // set this value - if it matches the value of one of the values in the select list, then that option will be selected
        });
      var statuscodes = SystemDB.StatusCodes.Where(s => s.StatusCodeId != 1);
      ViewBag.StatusCodeList = new SelectList(statuscodes, "StatusCodeId", "StatusCodeName"); // don't use 4th parameter
      return View(model);
    }
