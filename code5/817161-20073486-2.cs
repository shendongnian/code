    [HttpGet]
    public ActionResult AddVechicle()
    {
       return View(new Vehicle());
    }
    
    [HttpPost, ValidateInput(false)]
    public JsonResult AddVechicle(Vehicle newVehicle)
    {
       // I expect that newVechicle is populated via the form
    }
