    public ActionResult BookFlight()
    {
       var model = new FlightModel
       {
           DepartureList = GetAsSelectList()
       };
       return View(model);
    }
