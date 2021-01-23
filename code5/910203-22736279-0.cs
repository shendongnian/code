      [HttpGet]
      public ActionResult GetAllCars()
      {
            CarRentalEntities entities = new CarRentalEntities();
            var cars = entities.GetAllCars();    
    
            List<CarViewModel> carsViewModel = cars.Select(c=> new CarViewModel
            {
             Registration = c.Registration,
             // and so on
            }).ToList();
            
            return View(carsViewModel); 
      }
