    OdeToFoodDatabase _db = new OdeToFoodDatabase();
    public ActionResult Index()
    
    {
        var query = _db.Restaurants.ToList();
        var model = _db.Restaurants
                     .Take(20)
                     .Select(r => new ResturantViewModel
                      
    {  
                          Id=r.Id,
                          Name = r.Name
    
                       });
    
        return View(model);
    }
