    public ActionResult CreateNewRow()
    {
        //**create selectList in controller
        var carlist = new List<SelectListItem>();
        var cars = from n in db.Cars
                  select new SelectListItem
            {
                 Text = n.carname,
                 Value = n.CarID.ToString()
            };
        foreach (var item in cars)
        carlist.Add(item);
    
        ViewBag.cars = cars
    
        return View();
    }
