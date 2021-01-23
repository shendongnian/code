    [HttpPost]
    public ActionResult MakeBooking(BookingModel model)
    {
        TempData["TempBookingModel"]=model;
        return RedirectToAction("FinalBooking", "Booking");
    }
    public ActionResult FinalBooking()
    {       
        var model= TempData["TempBookingModel"] as BookingModel; 
        return View(model);
    }
